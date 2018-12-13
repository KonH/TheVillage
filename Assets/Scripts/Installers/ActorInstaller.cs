using Models;
using Repositories;
using ViewModels;
using Zenject;

namespace Installers {
	public class ActorInstaller : MonoInstaller {
		public ActorSettings Settings;
		public ActorViewModel ActorViewModelPrefab;
		
		public override void InstallBindings() {
			Container.Bind<ActorIdReposilory>().ToSelf().AsSingle();
			Container.Bind<ActorRepository>().ToSelf().AsSingle().WithArguments(Settings);
			Container.BindFactory<ActorModel, ActorViewModel, ActorViewModel.Factory>().FromComponentInNewPrefab(ActorViewModelPrefab);
		}
	}
}