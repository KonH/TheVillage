using Zenject;
using Controllers;

namespace Installers {
	public class StressInstaller : MonoInstaller {		
		public override void InstallBindings() {
			if ( enabled ) {
				Container.Bind(typeof(StressController), typeof(ITickable)).To<StressController>().AsSingle().NonLazy();
			}
		}
	}
}