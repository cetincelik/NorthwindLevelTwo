using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MvcWebUl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUl.Controllers
{
    public class CategoryController:Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

  
    }

}
