﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        Color Get(string name);
        void Add(Color entity);
        void Update(Color entity);
        void Delete(Color entity);



    }
}