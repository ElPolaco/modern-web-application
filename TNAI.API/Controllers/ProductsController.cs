using AutoMapper;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TNAI.API.Models.InputModels.Products;
using TNAI.API.Models.OutputModel.Products;
using TNAI.Model.Entitites;
using TNAI.Repository.Abstract;

namespace TNAI.API.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IMapper _mapper;
     
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository=productRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Pobieranie produktu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get(int id)
        {
            if(id<=0)return BadRequest();
            var product= await _productRepository.GetProductAsync(id);
            if(product==null)return NotFound();
            return Ok(Map(product));
            
        }
        /// <summary>
        /// Pobranie wszszytkich prodóktów
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> GetAll()
        {
            var products = await _productRepository.GetAllProductsAsync();
            if(products==null)return BadRequest();
            if(!products.Any())return NotFound();

            return Ok(Map(products));    

        }
        /// <summary>
        /// Dodanie produktu
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, type:typeof(ProductOutputModel))]
        //[SwaggerResponse(HttpStatusCode.BadRequest,type:)]
        public async Task<IHttpActionResult> Post(ProductInputModel model)
        {

            if (model == null) return BadRequest("Model is null");

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                CategoryId = model.CategoryId
            };
            var result = await _productRepository.SaveProductAsync(product);
            if (!result)
            {
                return InternalServerError();
            }
            var productOutput = await _productRepository.GetProductAsync(product.Id);
            return Ok(Map(productOutput));
        }
        /// <summary>
        /// Aktualizowanie produktów
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Put([FromUri]int id,[FromBody]ProductInputModel model)
        {
            if (model == null) return BadRequest("Model is null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = await _productRepository.GetProductAsync(id);
            if (product == null)
                return NotFound();
            product.Name = model.Name;
            product.Price = model.Price;
            product.CategoryId=model.CategoryId;
          
            var result = await _productRepository.SaveProductAsync(product);
            if (!result)
            {
                return InternalServerError();
            }
            return Ok(Map(product));
        }
        /// <summary>
        /// Usuwanie produktów
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            if (id <= 0) return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = await _productRepository.GetProductAsync(id);
            if (product == null)
                return NotFound();
            
            var result = await _productRepository.DeleteProductAsync(id);
            if (!result)
            {
                return InternalServerError();
            }
            return Ok();
        }
        private ProductOutputModel Map(Product product)
        {
            return _mapper.Map<ProductOutputModel>(product);
        }
        private List<ProductOutputModel> Map(List<Product> products)
        {
           return _mapper.Map<List<ProductOutputModel>>(products);
        }
    }
}
