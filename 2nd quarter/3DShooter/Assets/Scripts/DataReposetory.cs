using System;
using System.IO;
using UnityEngine;
using Game.Interfaces;

namespace Game.Data
{
    class DataReposetory
    {
        private IData<DataContainer> _data;
        private string _fileName;
        private string _path;
        public DataReposetory (IData<DataContainer> data, string folderName, string fileName)
        {
            _fileName = fileName;
            _data = data;
            _path = Path.Combine(Application.dataPath, folderName);
        }
        public void Save( DataContainer container)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            
            _data.Save(container, Path.Combine(_path, _fileName));
        }
        public DataContainer Load()
        {
            var file = Path.Combine(_path, _fileName);
            return _data.Load(file);
        }
    }
}
