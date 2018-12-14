using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UDBase.Controllers.LogSystem;
using Zenject;
using World;
using Actors.States;
using Models;
using Holders;
using Sources;
using Repositories;

namespace Actors {
	[RequireComponent(typeof(NavMeshAgent))]
	public class Actor : MonoBehaviour, ILogContext {
		public ActorModel    Model    { get; private set; }
		public ActorSettings Settings { get; private set; }
		public AreaHolder    Areas    { get; private set; }
		public NavMeshAgent  Agent    { get; private set; }

		public List<ActorState> States       { get; private set; }
		public ActorState       CurrentState { get; private set; }
		
		ULogger _logger;

		ActorRepository _repo;

		[Inject]
		public void Init(ILog log, ActorRepository repo, ActorSettings settings, AreaHolder areas) {
			_logger  = log.CreateLogger(this);
			_repo    = repo;
			Settings = settings;
			Areas    = areas;
		}

		void Start() {
			Model = _repo.Create();
			Agent = GetComponent<NavMeshAgent>();
			States = new List<ActorState> {
				new GoToHomeState(this),
				new IdleState(this),
				new GoToFoodState(this),
				new CollectFoodState(this),
				new EatFoodState(this, 1.5f)
			};
		}

		void OnTriggerEnter(Collider other) {
			_logger.MessageFormat("OnTriggerEnter: {0}", other.gameObject);
			var area = other.gameObject.GetComponent<Area>();
			if ( area ) {
				area.Visitors.Add(this);
				_logger.MessageFormat("Entering area: {0}", area);
				return;
			}
			var food = other.gameObject.GetComponent<FoodSource>();
			if ( food ) {
				Destroy(food.gameObject);
				Model.Inventory.Add(food.Model);
			}
		}
		
		void OnTriggerExit(Collider other) {
			_logger.MessageFormat("OnTriggerExit: {0}", other.gameObject);
			var area = other.gameObject.GetComponent<Area>();
			if ( area ) {
				area.Visitors.Remove(this);
				_logger.MessageFormat("Leaving area: {0}", area);
			}
		}

		void Update() {
			if ( (CurrentState == null) || CurrentState.Update() ) {
				TryChangeState();
			}
		}

		public bool IsInside(Area area) => (area != null) && area.Visitors.Contains(this);

		public bool IsInside(AreaType type) => GetAreaInside(type) != null;

		public Area GetAreaInside(AreaType type) => Areas.GetAreaInside(this, type);
		
		void TryChangeState() {
			var betterState = GetBetterState();
			if ( betterState != CurrentState ) {
				_logger.MessageFormat("Changing state to {0}", betterState);
			}
			CurrentState?.OnExit();
			CurrentState = betterState;
			CurrentState.OnEnter();
			Model.State = CurrentState.Name;
		}

		ActorState GetBetterState() {
			ActorState betterState    = null;
			var        betterPriority = float.MinValue;
			foreach ( var state in States ) {
				var priority = state.RefreshPriority();
				if ( priority > betterPriority ) {
					betterState    = state;
					betterPriority = priority;
				}
			}
			return betterState;
		}

	#if UNITY_EDITOR
		void OnDrawGizmos() {
			Handles.Label(transform.position, CurrentState.Name);
			if ( Agent.hasPath ) {
				Gizmos.color = Color.green;
				Gizmos.DrawLine(transform.position, Agent.destination);
			}
		}
	#endif

		public class Factory : Factory<Actor> {}
	}
}