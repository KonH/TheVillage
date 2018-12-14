using Zenject;
using Controllers;

namespace Installers {
	public class HungerInstaller : MonoInstaller {		
		public override void InstallBindings() {
			if ( enabled ) {
				Container.Bind(typeof(HungerController), typeof(ITickable)).To<HungerController>().AsSingle().NonLazy();
			}
		}
	}
}