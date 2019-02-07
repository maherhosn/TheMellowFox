using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MFoxGame.Models;
using MFoxGame.ViewModels;

namespace MFoxGame.Services
{
    public sealed class MockDataStore : IDataStore
    {

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static MockDataStore _instance;

        public static MockDataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MockDataStore();
                }
                return _instance;
            }
        }

        private List<Item> _itemDataset = new List<Item>();
        private List<Character> _characterDataset = new List<Character>();
        private List<Monster> _monsterDataset = new List<Monster>();
        private List<Score> _scoreDataset = new List<Score>();

        private MockDataStore()
        {
            InitilizeSeedData();
        }

        private void InitilizeSeedData()
        {

            // Implement

            // Load Items.

            _itemDataset.Add(new Item("Flaming Sword", "Sword made of Gold and Fire, can cut and incenrate enemies","https://razedinflames.com/wp-content/uploads/2018/05/giphy-2.gif", 0, 20, 10, ItemLocationEnum.PrimaryHand, AttributeEnum.Attack));                     
            _itemDataset.Add(new Item("Unbreakable Shield", "Can shield against bullets","https://media0.giphy.com/media/l0HlymZ7Jv6JoiYjC/giphy.gif?cid=3640f6095c4b0f456e5670486fff8e50", 1, 15, 1, ItemLocationEnum.OffHand, AttributeEnum.Defense));
            _itemDataset.Add(new Item("Hermes Shoes", "Lets the wearer soar in flight","https://image.shutterstock.com/image-vector/silhouette-running-shoe-wings-symbol-260nw-250466389.jpg", 2, 10, 2, ItemLocationEnum.Feet, AttributeEnum.Speed));                             
            _itemDataset.Add(new Item("Mighty Hammer", "Breaks the earth in half when you pound the ground","https://media.forgecdn.net/avatars/96/159/636282785986608670.jpeg", 3, 8, 3, ItemLocationEnum.PrimaryHand, AttributeEnum.Attack));
            _itemDataset.Add(new Item("Magician's Staff", "Can heal any injury","http://img.cadnav.com/allimg/140730/1-140I0221234.jpg", 4, 7, 4, ItemLocationEnum.OffHand, AttributeEnum.MaxHealth));


            // Implement Characters

            _characterDataset.Add(new Character("Elf", "Swift and Right with the bow and arrow", "https://lh3.googleusercontent.com/AcJw0jufTk2b1KpP1pZtnYIFcgMh-FiT0cx2-B5nH9eoKIQO0WbQJ805o1_NtKCeaCza4Q=s85", 25, 1));
            _characterDataset.Add(new Character("Dwarf", "Thunder Smash with the mighty hammer item", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRJYYpcY13YMAP9U20VnHMR4Yv9p4cgIh8U38LJF5vJV3LPKK9E", 26, 1));
            _characterDataset.Add(new Character("Magician", "Healing Powers with the magical staff item", "https://lh3.googleusercontent.com/MsElJWT-N9QoUErgaP6FiE_V0BcNMmm7Jf5bm-62WI8UNncD7GbTFAl-bFBsLPGhKetd=s85", 27, 1));
            _characterDataset.Add(new Character("Knight", "Fire Sword item", "https://lh3.googleusercontent.com/zB6yh46na6pE7sx5Yy7tI0m9ZsYYA20swE48q2Axdco-ZF-VnrQo1zmFA0-M0NUjX3zz=s85", 25, 1));
            _characterDataset.Add(new Character("Ninja", "Can Fight and destroy enemies without weapons", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQIbnctUwIojOfUGyjrObM0rpzjjWp4Urp3kE7PqYCsL9W3EQhthw", 28, 1));
            _characterDataset.Add(new Character("Mellow Fox", "Super Sly, skips level ", "https://lh3.googleusercontent.com/mZuEym-n-HLYiXXr4RBg-dt-FlJ4AUFETotg8R68bFWnfGPwhI-dev7Ft3x1zDVqDCWQaQ=s116", 30, 1));

            /*
            var mockCharacters = new List<Character>
            {
                new Character { Id = Guid.NewGuid().ToString(), Name = "First Character", Description="This is an Character description.", Age = 1 },
                new Character { Id = Guid.NewGuid().ToString(), Name = "Second Character", Description="This is an Character description." , Age = 1},
                new Character { Id = Guid.NewGuid().ToString(), Name = "Third Character", Description="This is an Character description." , Age = 2},
                new Character { Id = Guid.NewGuid().ToString(), Name = "Fourth Character", Description="This is an Character description." , Age = 2},
                new Character { Id = Guid.NewGuid().ToString(), Name = "Fifth Character", Description="This is an Character description." , Age = 3},
                new Character { Id = Guid.NewGuid().ToString(), Name = "Sixth Character", Description="This is an Character description." , Age = 3},
            };

            foreach (var data in mockCharacters)
            {
                _characterDataset.Add(data);
            }
            */

            // Implement Monsters

            // Implement Scores
        }

        private void CreateTables()
        {
            // Do nothing...
        }

        // Delete the Datbase Tables by dropping them
        public void DeleteTables()
        {
            // Implement
        }

        // Tells the View Models to update themselves.
        private void NotifyViewModelsOfDataChange()
        {
            ItemsViewModel.Instance.SetNeedsRefresh(true);
            // Implement Monsters

            // Implement Characters 

            // Implement Scores
        }

        public void InitializeDatabaseNewTables()
        {
            DeleteTables();

            // make them again
            CreateTables();

            // Populate them
            InitilizeSeedData();

            // Tell View Models they need to refresh
            NotifyViewModelsOfDataChange();
        }

        #region Item
        // Item
        public async Task<bool> InsertUpdateAsync_Item(Item data)
        {

            // Check to see if the item exist
            var oldData = await GetAsync_Item(data.Id);
            if (oldData == null)
            {
                _itemDataset.Add(data);
                return true;
            }

            // Compare it, if different update in the DB
            var UpdateResult = await UpdateAsync_Item(data);
            if (UpdateResult)
            {
                await AddAsync_Item(data);
                return true;
            }

            return false;
        }

        public async Task<bool> AddAsync_Item(Item data)
        {
            _itemDataset.Add(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Item(Item data)
        {
            var myData = _itemDataset.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return false;
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Item(Item data)
        {
            var myData = _itemDataset.FirstOrDefault(arg => arg.Id == data.Id);
            _itemDataset.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetAsync_Item(string id)
        {
            return await Task.FromResult(_itemDataset.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetAllAsync_Item(bool forceRefresh = false)
        {
            return await Task.FromResult(_itemDataset);
        }

        #endregion Item

        #region Character
        // Character
        public async Task<bool> InsertUpdateAsync_Character(Character data)
        {

            // Check to see if the item exist
            var oldData = await GetAsync_Character(data.Id);
            if (oldData == null)
            {
                _characterDataset.Add(data);
                return true;
            }

            // Compare it, if different update in the DB
            var UpdateResult = await UpdateAsync_Character(data);
            if (UpdateResult)
            {
                await AddAsync_Character(data);
                return true;
            }

            return false;
        }


        public async Task<bool> AddAsync_Character(Character data)
        {
            // Implement
            _characterDataset.Add(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Character(Character data)
        {
            var myData = _characterDataset.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return false;
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Character(Character data)
        {
            var myData = _characterDataset.FirstOrDefault(arg => arg.Id == data.Id);
            _characterDataset.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Character> GetAsync_Character(string id)
        {
            return await Task.FromResult(_characterDataset.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Character>> GetAllAsync_Character(bool forceRefresh = false)
        {
            return await Task.FromResult(_characterDataset);
        }

        #endregion Character

        #region Monster
        //Monster
        public async Task<bool> AddAsync_Monster(Monster data)
        {
            // Implement
            return false;
        }

        public async Task<bool> UpdateAsync_Monster(Monster data)
        {
            // Implement
            return false;
        }

        public async Task<bool> DeleteAsync_Monster(Monster data)
        {
            // Implement
            return false;
        }

        public async Task<Monster> GetAsync_Monster(string id)
        {
            // Implement
            return null;
        }

        public async Task<IEnumerable<Monster>> GetAllAsync_Monster(bool forceRefresh = false)
        {
            // Implement
            return null;
        }

        #endregion Monster

        #region Score
        // Score
        public async Task<bool> AddAsync_Score(Score data)
        {
            // Implement
            return false;
        }

        public async Task<bool> UpdateAsync_Score(Score data)
        {
            // Implement
            return false;
        }

        public async Task<bool> DeleteAsync_Score(Score data)
        {
            // Implement
            return false;
        }

        public async Task<Score> GetAsync_Score(string id)
        {
            // Implement
            return null;
        }

        public async Task<IEnumerable<Score>> GetAllAsync_Score(bool forceRefresh = false)
        {
            // Implement
            return null;
        }
        #endregion Score
    }
}