using Actors;
using Models;
using Repositories;
using Spawners;
using ViewModels;
using Zenject;

namespace Installers {
	public class ActorInstaller : MonoInstaller {
		public ActorSettings Settings;
		public Actor ActorPrefab;
		public ActorViewModel ActorViewModelPrefab;
		public ActorSpawner Spawner;
		
		public override void InstallBindings() {
			Container.Bind<ActorIdReposilory>().ToSelf().AsSingle();
			Container.Bind<ActorRepository>().ToSelf().AsSingle().WithArguments(Settings);
			Container.BindFactory<Actor, Actor.Factory>().FromComponentInNewPrefab(ActorPrefab);
			Container.BindFactory<ActorModel, ActorViewModel, ActorViewModel.Factory>().FromComponentInNewPrefab(ActorViewModelPrefab);
			Container.BindInstance(Spawner);
		}
	}
}