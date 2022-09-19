using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using PAPI.Core.DTOs;
using PAPI.Core.Models;
using PAPI.Core.Services;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using PAPI.Repository;

namespace PAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsPhotoController : CustomBaseController
    {
        public static IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        private readonly IService<ProductPhoto> _service;
        private readonly IProductService _productService;

        public ProductsPhotoController(IService<ProductPhoto> service, IMapper mapper, IWebHostEnvironment webHostEnvironment, IHostingEnvironment hostingEnv, AppDbContext context, IProductService productService)
        {
            _webHostEnvironment = webHostEnvironment;
            _service = service;
            _mapper = mapper;
            _hostingEnvironment = hostingEnv;
            _context = context;
            _productService = productService;
        }
        public IHostingEnvironment _hostingEnvironment;
        public AppDbContext _context;
        




        [HttpGet]
        public async Task<IActionResult> All()
        {
            var photos = await _service.GetAllAsync();
            var photosDto = _mapper.Map<List<ProductPhotoDto>>(photos.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductPhotoDto>>.Succes(200, photosDto));
        }

        

        [HttpPost]
        public async Task<IActionResult> Save(ProductPhotoDto productPhotosDto)
        {
            var product = await _service.AddAsync(_mapper.Map<ProductPhoto>(productPhotosDto));
            var productDto = _mapper.Map<ProductPhotoDto>(product);
            return CreateActionResult(CustomResponseDto<ProductPhotoDto>.Succes(201, productDto));
        }

        //[HttpPost("multiple-files")]
        //public async Task Upload(List<IFormFile> files)
        //{
        //    // validate the files, scan virus, save them to a file storage
        //}

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(List<IFormFile> files, int productId)
        {

            try
            {
                //var files = HttpContext.Request.Form.Files;
                if (files != null && files.Count > 0)
                {

                    var photosProductId = await _service.GetByIdAsync(productId);
                    return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(200));

                    //TODO ProductId ye göre resimler getirilecek 
                    foreach (var file in files)
                    {
                        FileInfo fi = new FileInfo(file.FileName);
                        var newfilename = $"{file.FileName.Replace(fi.Extension,"")}_{ Guid.NewGuid().ToString()}{fi.Extension}";
                        var path = Path.Combine(_hostingEnvironment.ContentRootPath,"Images", newfilename);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        ProductPhoto productPhoto = new ProductPhoto();
                        productPhoto.Url = $"Images/{newfilename}";

                        productPhoto.ProductId = productId;
                        productPhoto.Title = file.FileName;
                        _context.ProductPhotos.Add(productPhoto);
                        _context.SaveChanges();

                    }
                    return Ok();
                }
                else
                {
                    return BadRequest("Dosya seçilmedi");
                }
            }
            catch (Exception e1)
            {

                return (ActionResult)CreateActionResult(CustomResponseDto<NoContentDto>.Fail(500, e1.Message));
            }


            //Guid   Guid.NewGuid()

        }

        //[HttpGet("RemoveImage/{]

        
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Remove(int id)
        //{
        //    var photo = await _service.GetByIdAsync(id);
        //    await _service.RemoveAsync(photo);          
        //}
       

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Remove(int id)
        //{
        //    var photo = await _service.GetByIdAsync(id);
        //    await _service.RemoveAsync(photo);
        //    return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(200));
        //}

    }
}
