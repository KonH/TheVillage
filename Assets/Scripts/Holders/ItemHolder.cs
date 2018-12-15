using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.LogSystem;
using Zenject;
using Models;

namespace Holders {
	public class ItemHolder : MonoBehaviour, ILogContext {
		public List<ItemModel> Items = new List<ItemModel>();

		ULogger _logger;
		
		[Inject]
		public void Init(ILog log) {
			_logger = log.CreateLogger(this);
		}
		
		public void Add(ItemModel item, ActorModel byActor) {
			byActor.Inventory.Remove(item);
			Items.Add(item);
			byActor.Gold += item.Price;
			_logger.MessageFormat("Add: {0} by {1} ({2})", item.Name, byActor.Id.Name, Items.Count);
		}

		public ItemModel Peek(Func<ItemModel, bool> selector) {
			return Items.Where(selector).FirstOrDefault();
		}
		
		public void Get(ItemModel item, ActorModel byActor) {
			Items.Remove(item);
			byActor.Inventory.Add(item);
			byActor.Gold -= item.Price;
			_logger.MessageFormat("Get: {0} by {1} ({2})", item.Name, byActor.Id.Name, Items.Count);
		}
	}
}