using Zenject;
using Actors;
using Models;
using Spawners;
using ViewModels;
using Repositories;

namespace Installers {
	public class ActorInstaller : MonoInstaller {
		public ActorSettings  Settings;
		public Actor          ActorPrefab;
		public ActorViewModel ActorViewModelPrefab;
		public ActorSpawner   Spawner;
		
		public override void InstallBindings() {
			Container.BindInstance(Settings);
			Container.BindInstance(Spawner);
			Container.Bind<ActorIdReposilory>().ToSelf().AsSingle();
			Container.Bind<ActorRepository>().ToSelf().AsSingle();
			Container.BindFactory<Actor, Actor.Factory>().FromComponentInNewPrefab(ActorPrefab);
			Container.BindFactory<ActorModel, ActorViewModel, ActorViewModel.Factory>().FromComponentInNewPrefab(ActorViewModelPrefab);
			Container.BindFactory<ActorBehaviourModel, ActorBehaviourModel.Factory>().FromNew();
		}
	}
}