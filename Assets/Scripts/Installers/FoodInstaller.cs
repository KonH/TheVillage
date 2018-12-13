using Zenject;
using Repositories;

namespace Installers {
	public class FoodInstaller : MonoInstaller {
		public FoodRepository.Settings Settings;
		
		public override void InstallBindings() {
			Container.Bind<FoodRepository>().ToSelf().AsSingle().WithArguments(Settings);
		}
	}
}