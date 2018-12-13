using UDBase.Installers;
using UDBase.Controllers.LogSystem;
using Holders;
using Sources;

namespace Installers {
	public class GameInstaller : UDBaseSceneInstaller {
		public UnityLog.Settings LogSettings;
		public AreaHolder        AreaHolder;
		public FoodSource        FoodSourcePrefab;
		
		public override void InstallBindings() {
			AddUnityLogger(LogSettings);

			Container.BindInstance(AreaHolder);
			Container.BindFactory<FoodSourceHolder, FoodSource, FoodSource.Factory>().FromComponentInNewPrefab(FoodSourcePrefab);
		}
	}
}