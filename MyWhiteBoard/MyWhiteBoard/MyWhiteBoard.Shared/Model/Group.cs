using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace MyWhiteBoard.Model
{
    public class Group
    {
        public string Title { get; set; }
        public ObservableCollection<Task> Items { get; set; }

        public Group()
        {
            Items = new ObservableCollection<Task>();
        }
    }

    public class StoreData
    {
        public StoreData()
        {
            Task item;

            item = new Task();
            item.Detail = "Banana Blast Frozen Yogurt 1";
            item.PersonAffected = "Diégo Da Costa Oliveira";
            item.Day = "Lundi";
            Collection.Add(item);

            item = new Task();
            item.Detail = "Banana Blast Frozen Yogurt 2";
            item.PersonAffected = "Diégo Da Costa Oliveira";
            item.Day = "Lundi";
            Collection.Add(item);

            item = new Task();
            item.Detail = "Banana Blast Frozen Yogurt 3";
            item.PersonAffected = "Diégo Da Costa Oliveira";
            item.Day = "Lundi";
            Collection.Add(item);

            item = new Task();
            item.Detail = "Banana Blast Frozen Yogurt 4";
            item.PersonAffected = "Diégo Da Costa Oliveira";
            item.Day = "Lundi";
            Collection.Add(item);

            item = new Task();
            item.Detail = "Banana Blast Frozen Yogurt 5";
            item.PersonAffected = "Diégo Da Costa Oliveira";
            item.Day = "Mardi";
            Collection.Add(item);

            item = new Task();
            item.Detail = "Banana Blast Frozen Yogurt 6";
            item.PersonAffected = "Diégo Da Costa Oliveira";
            item.Day = "Mercredi";
            Collection.Add(item);

            item = new Task();
            item.Detail = "Banana Blast Frozen Yogurt 7";
            item.PersonAffected = "Diégo Da Costa Oliveira";
            item.Day = "Lundi";
            Collection.Add(item);

            item = new Task();
            item.Detail = "Banana Blast Frozen Yogurt 8 ";
            item.PersonAffected = "Diégo Da Costa Oliveira";
            item.Day = "Jeudi";
            Collection.Add(item);

            item = new Task();
            item.Detail = "Banana Blast Frozen Yogurt";
            item.PersonAffected = "Diégo Da Costa Oliveira";
            item.Day = "Lundi";
            Collection.Add(item);

            item = new Task();
            item.Detail = "Banana Blast Frozen Yogurt";
            item.PersonAffected = "Diégo Da Costa Oliveira";
            item.Day = "Vendredi";
            Collection.Add(item);

            item = new Task();
            item.Detail = "Banana Blast Frozen Yogurt";
            item.PersonAffected = "Diégo Da Costa Oliveira";
            item.Day = "Lundi";
            Collection.Add(item);

            item = new Task();
            item.Detail = "Banana Blast Frozen Yogurt";
            item.PersonAffected = "Diégo Da Costa Oliveira";
            item.Day = "Lundi";
            Collection.Add(item);
        }



        private ItemCollection _Collection = new ItemCollection();

        public ItemCollection Collection
        {
            get
            {
                return this._Collection;
            }
        }

        internal List<GroupInfoList<object>> GetGroupsByDay()
        {
            List<GroupInfoList<object>> groups = new List<GroupInfoList<object>>();

            var query = from item in Collection
                        orderby ((Task)item).Day
                        group item by ((Task)item).Day into g
                        select new { GroupName = g.Key, Items = g };
            foreach (var g in query)
            {
                GroupInfoList<object> info = new GroupInfoList<object>();
                info.Key = g.GroupName;
                foreach (var item in g.Items)
                {
                    info.Add(item);
                }
                groups.Add(info);
            }

            return groups;

        }
    }

    public class ItemCollection : ObservableCollection<Object>
    {
        private System.Collections.ObjectModel.ObservableCollection<Task> itemCollection = new System.Collections.ObjectModel.ObservableCollection<Task>();
    }

    public class GroupInfoList<T> : List<object>
    {

        public object Key { get; set; }


        public new IEnumerator<object> GetEnumerator()
        {
            return (System.Collections.Generic.IEnumerator<object>)base.GetEnumerator();
        }
    }
}
