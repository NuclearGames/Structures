﻿using System.Collections;
using System.Collections.Generic;
using Structures.NetSixZero.Utils.Collections.Interfaces;


namespace Structures.NetSixZero.Structures.BCST {
    /// <summary>
    /// Узел двочиного дерева, включающий в себя несколько элементов
    /// </summary>
    public class CollectionNode<TData, TCollection> : IAnyElementCollection<TData> where TCollection : IAnyElementCollection<TData>, new() {

        private readonly TCollection _dataCollection;
        
        /// <summary>
        /// Левый дочерний узел элемента
        /// </summary>
        public CollectionNode<TData, TCollection>? Left { get; set; }
        
        /// <summary>
        /// Правый дочерний узел элемента
        /// </summary>
        public CollectionNode<TData, TCollection>? Right { get; set; }

        public CollectionNode(TData data, CollectionNode<TData, TCollection>? left = null, CollectionNode<TData, TCollection>? right = null) {
            _dataCollection = new TCollection {
                data
            };
            Left = left;
            Right = right;
        }

        public override string ToString() {
            if (!_dataCollection.TryGetAny(out var value)) {
                return $"#-- x {_dataCollection.Count}; L{(Left == null ? "-" : "+")}; R{(Right == null ? "-" : "+")}"; 
            }
            
            return $"#{(value)} x {_dataCollection.Count}; L{(Left == null ? "-" : "+")}; R{(Right == null ? "-" : "+")}";
        }

#region IAny

        /// <summary>
        /// Пустая ли коллекция
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Любой элемент из коллекции
        /// </summary>
        public TData Any => _dataCollection.Any;
        
        /// <summary>
        /// Есть ли в коллекции хотя бы один элемент
        /// </summary>
        /// <param name="value">Любой элемент, если он существует в коллекции</param>
        public bool TryGetAny(out TData? value) {
            return _dataCollection.TryGetAny(out value);
        }

#endregion

#region ICollection

        public int Count => _dataCollection.Count;
        public bool IsReadOnly => false;

        // public TData this[int index] {
        //     get => _dataCollection[index];
        //     set => _dataCollection[index] = value;
        // }

        public void Add(TData item) => _dataCollection.Add(item);

        public void AddRange(IEnumerable<TData> dataEnumerable) {
            foreach (var data in dataEnumerable) {
                _dataCollection.Add(data);
            }
        }

        public void Clear() => _dataCollection.Clear();

        public bool Contains(TData item) => _dataCollection.Contains(item);

        // public int IndexOf(TData item) => _dataCollection.IndexOf(item);

        public bool Remove(TData item) => _dataCollection.Remove(item);
        
        // public void RemoveAt(int index) => _dataCollection.RemoveAt(index);
        
        void ICollection<TData>.CopyTo(TData[] array, int arrayIndex) => _dataCollection.CopyTo(array, arrayIndex);

        // void IList<TData>.Insert(int index, TData item) => _dataCollection.Insert(index, item);

#region Enumerable

        public IEnumerator<TData> GetEnumerator() {
            return _dataCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

#endregion

#endregion
    }
}