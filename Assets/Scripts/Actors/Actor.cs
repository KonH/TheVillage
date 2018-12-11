using System.Collections.Generic;
using Actors.States;
using Holders;
using Models;
using Repositories;
using Sources;
using UDBase.Controllers.LogSystem;
using UnityEngine;
using UnityEngine.AI;
using World;
using Zenject;

namespace Actors {
	[RequireComponent(typeof(NavMeshAgent))]
	public class Actor : MonoBehaviour, ILogContext {
		public AreaHolder Areas { get; private set; }
		public NavMeshAgent Agent { get; private set; }

		ULogger _logger;

		ActorModel _model;
		ActorState _state;
		List<ActorState> _states;

		[Inject]
		public void Init(ILog log, ActorRepository repo, AreaHolder areas) {
			_logger = log.CreateLogger(this);
			_model = repo.State;
			Areas = areas;
		}

		void Start() {
			Agent = GetComponent<NavMeshAgent>();
			_states = new List<ActorState> {
				new IdleState(this),
				new GoToFoodState(this),
				new CollectFoodState(this)
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
				_model.Inventory.Add(new FoodItemModel());
			}
		}
		
		void OnTriggerExit(Collider other) {
			var area = other.gameObject.GetComponent<Area>();
			if ( area ) {
				area.Visitors.Remove(this);
				_logger.MessageFormat("Leaving area: {0}", area);
			}
		}

		void Update() {
			if ( (_state == null) || _state.Update() ) {
				TryChangeState();
			}
		}

		public bool IsInside(Area area) => area.Visitors.Contains(this);

		public Area GetAreaInside(AreaType type) {
			foreach ( var area in Areas.Filter(type) ) {
				if ( area.Visitors.Contains(this) ) {
					return area;
				}
			}
			return null;
		}
		
		void TryChangeState() {
			var betterState = GetBetterState();
			_state?.OnExit();
			if ( betterState != _state ) {
				_logger.MessageFormat("Changing state to {0}", betterState);
			}
			_state = betterState;
			_state.OnEnter();
			_model.State = _state.GetType().Name;
		}

		ActorState GetBetterState() {
			ActorState betterState    = null;
			var        betterPriority = float.MinValue;
			foreach ( var state in _states ) {
				var priority = state.UpdatePriority();
				if ( priority > betterPriority ) {
					betterState    = state;
					betterPriority = priority;
				}
			}
			return betterState;
		}
	}
}