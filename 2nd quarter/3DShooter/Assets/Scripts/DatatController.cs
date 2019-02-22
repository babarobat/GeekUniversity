using Game.Interfaces;
using UnityEngine;
using Game.Data;

namespace Game
{
    class DatatController : BaseController
    {
        private IInput _input;
        public DatatController(IInput input)
        {
            _input = input;
            _input.OnSave += Save;
            _input.OnLoad += Load;
        }
        public void Save()
        {
            if (!IsActive) return;
            MonoBehaviour.print("Game Saved");
            IData<DataContainer> data = new JsonData<DataContainer>();
            DataReposetory datarepo = new DataReposetory(data, "Data", "PlayerData");
            DataContainer container = new DataContainer();
            container.Position = MonoBehaviour.FindObjectOfType<PlayerMoveModel>().transform.position;
            datarepo.Save(container);
        }
        public void Load()
        {
            if (!IsActive) return;
            MonoBehaviour.print("Game Loaded");
            IData<DataContainer> data = new JsonData<DataContainer>();
            DataReposetory datarepo = new DataReposetory(data, "Data", "PlayerData");
            MonoBehaviour.FindObjectOfType<PlayerMoveModel>().transform.position = datarepo.Load().Position;
        }
    }
}
