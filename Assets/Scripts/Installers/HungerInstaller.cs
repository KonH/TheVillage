using Controllers;
using Zenject;

namespace Installers {
	public class HungerInstaller : MonoInstaller {
		public HungerController.Settings Settings;
		
		public override void InstallBindings() {
			if ( enabled ) {
				Container.Bind(typeof(HungerController), typeof(ITickable)).To<HungerController>().AsSingle().WithArguments(Settings).NonLazy();
			}
		}
	}
}