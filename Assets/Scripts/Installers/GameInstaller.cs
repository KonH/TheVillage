using Sources;
using UDBase.Installers;

namespace Installers {
	public class GameInstaller : UDBaseSceneInstaller {
		public FoodSource FoodSourcePrefab;
		
		public override void InstallBindings() {
			Container.BindFactory<FoodSource, FoodSource.Factory>().FromComponentInNewPrefab(FoodSourcePrefab);
		}
	}
}