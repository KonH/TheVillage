using Models;
using Repositories;
using Zenject;

namespace Installers {
	public class FoodInstaller : MonoInstaller {
		public FoodRepository.Settings Settings;
		
		public override void InstallBindings() {
			Container.Bind<FoodRepository>().ToSelf().AsSingle().WithArguments(Settings);
		}
	}
}