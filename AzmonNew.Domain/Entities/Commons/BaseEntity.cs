﻿using System;

namespace AzmonNew.Domain.Entities.Commons
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime? RemoveTime { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {

    }

}
