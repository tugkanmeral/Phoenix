﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Phoenix.LayerBases.Entity
{
    public interface IEntity<TId>
    {
        public TId Id { get; set; }
    }
}
