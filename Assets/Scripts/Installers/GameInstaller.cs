using Holders;
using Repositories;
using Sources;
using UDBase.Controllers.LogSystem;
using UDBase.Installers;
using UnityEngine;

namespace Installers {
	public class GameInstaller : UDBaseSceneInstaller {
		[Header("UDBase")]
		public UnityLog.Settings LogSettings;
		
		[Header("Logics")]
		public AreaHolder AreaHolder;
		
		[Header("Prefabs")]
		public FoodSource FoodSourcePrefab;
		
		public override void InstallBindings() {
			AddUnityLogger(LogSettings);

			Container.BindInstance(AreaHolder);
			Container.BindFactory<FoodSourceHolder, FoodSource, FoodSource.Factory>().FromComponentInNewPrefab(FoodSourcePrefab);
		}
	}
}