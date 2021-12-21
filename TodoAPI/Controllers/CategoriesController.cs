using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Dtos;
using TodoAPI.Models;
using TodoAPI.Repositories.Interfaces;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepo, IMapper maper)
        {
            _categoryRepo = categoryRepo;
            _mapper = maper;
        }
        
        [HttpGet]
        public IActionResult GetCategory()
        {
            var categories = _categoryRepo.GetCategories();
            var categoryDtos = new List<CategoryDto>();
            foreach(var item in categories)
            {
                categoryDtos.Add(_mapper.Map<CategoryDto>(item));
            }
            return Ok(categoryDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _categoryRepo.GetCategory(id);
            if (category == null) return NotFound();
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return Ok(categoryDto);
        }


        [HttpPost]
        public IActionResult CreateCategory(CategoryDto categoryDto)
        {
            if (categoryDto == null) return BadRequest();
            if (_categoryRepo.CategoryExist(categoryDto.CategoryName))
            {
                ModelState.AddModelError("", "This category already existed...!");
                return BadRequest(ModelState);
            }
            var category = _mapper.Map<Category>(categoryDto);
            if (!_categoryRepo.CreateCategory(category))
            {
                ModelState.AddModelError("", "Error when create a category...!");
                return BadRequest(ModelState);
            }
            return Ok(category);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateCategory(int id, CategoryDto categoryDto)
        {
            if (categoryDto.CategoryId != id || categoryDto == null) return BadRequest();
            var UpdateCategory = _mapper.Map<Category>(categoryDto);
            if (!_categoryRepo.UpdateCategory(UpdateCategory))
                return BadRequest("Update failed...!");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryRepo.GetCategory(id);
            if (category == null) return NotFound();
            return Ok(_categoryRepo.DeleteCategory(category));
        }
    }
}
