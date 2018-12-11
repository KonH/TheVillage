using Models;
using Repositories;
using Zenject;

namespace Installers {
	public class ActorInstaller : MonoInstaller {
		public ActorSettings Settings;
		
		public override void InstallBindings() {
			Container.Bind<ActorRepository>().ToSelf().AsSingle().WithArguments(Settings);
		}
	}
}