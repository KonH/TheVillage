using UDBase.Installers;
using UDBase.Controllers.LogSystem;
using Holders;
using Sources;
using World;

namespace Installers {
	public class GameInstaller : UDBaseSceneInstaller {
		public UnityLog.Settings LogSettings;
		public AreaSettings      AreaSettings;
		public AreaHolder        AreaHolder;
		public FoodSource        FoodSourcePrefab;
		
		public override void InstallBindings() {
			AddUnityLogger(LogSettings);

			Container.BindInstance(AreaSettings);
			Container.BindInstance(AreaHolder);
			Container.BindFactory<FoodSourceHolder, FoodSource, FoodSource.Factory>().FromComponentInNewPrefab(FoodSourcePrefab);
		}
	}
}