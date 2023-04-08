using AutoMapper;
using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repository.Abstract;
using BulkyBookWeb.Repository.Concrete;
using BulkyBookWeb.ViewModels;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _productRepository;
        private readonly IValidator<Product> _validator;

        public ProductController(IMapper mapper, IRepository<Product> productRepository , IValidator<Product> validator)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _validator = validator;
        }

        [HttpGet]
        [Route("products")]
        public IActionResult Index()
        {
            //bütün ürünler çekiliyor
            var products = _productRepository.GetAll();

            //AutoMap ile map işlemi yaptım
            var ProductViewModel = _mapper.Map<List<ProductViewModel>>(products);

            return View(ProductViewModel); //pass productviewmodel parametre olarak view'e aktarıyorum
        }

        [HttpGet]
        [Route("products/create")]
        public IActionResult Create()
        {
         
            return View();
        }

        [HttpPost]
        [Route("products/create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Product obj)
        {

            ValidationResult result = _validator.Validate(obj);


            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    
                    ModelState.AddModelError(error.PropertyName.ToString(),error.ErrorMessage);
                }
                return View(obj);
            }

            _productRepository.Add(obj);
			TempData["success"] = "Ürün başarıyla eklendi";
			return RedirectToAction("Index");

        }

        //EDIT
        [HttpGet]
		[Route("products/edit/{id}")]
		public IActionResult Edit(int? id)
		{
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var product = _productRepository.GetById(p=>p.Id == id);
			if(product == null)
            {
                return NotFound();
            }

			var mappedProduct = _mapper.Map<ProductViewModel>(product);
			return View(mappedProduct);
		}

		[HttpPost]
		[Route("products/edit/{id}")]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(ProductViewModel obj)
		{
            var mappedProduct = _mapper.Map<Product>(obj);

			ValidationResult result = _validator.Validate(mappedProduct);


			if (!result.IsValid)
			{
				foreach (var error in result.Errors)
				{

					ModelState.AddModelError(error.PropertyName.ToString(), error.ErrorMessage);
				}
				return View(obj);
			}
			
            _productRepository.Update(mappedProduct);
			TempData["success"] = "Ürün başarıyla güncellendi";
			return RedirectToAction("Index");
		}

        //DELETE

		[HttpGet]
		[Route("products/delete/{id}")]
		public IActionResult Delete(int? id)
		{
			if (id == 0 || id == null)
			{
				return NotFound();
			}

			var product = _productRepository.GetById(p => p.Id == id);
			if (product == null)
			{
				return NotFound();
			}

            var mappedProduct = _mapper.Map<ProductViewModel>(product);
			return View(mappedProduct);
		}

		[HttpPost]
		[Route("products/delete/{id}")]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(Product obj)
		{
			
			_productRepository.Delete(obj);
            TempData["success"] = "Ürün başarıyla silindi";
			return RedirectToAction("Index");
		}


	}
}
