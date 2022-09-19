using AutoMapper;
using PAPI.Core.DTOs;
using PAPI.Core.Models;
using PAPI.Core.Repositories;
using PAPI.Core.Services;
using PAPI.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace PAPI.Service.Services
//{
//    public class PhotosWithProductService : Service<ProductPhoto>, IPhotoService
//    {

//        private readonly IPhotoRepository _photoRepository;
//        private readonly IMapper _mapper;
//        public PhotosWithProductService(IGenericRepository<ProductPhoto> repository, IUnitOfWorks unitOfWork, IPhotoRepository photoRepository, IMapper mapper) : base(repository, unitOfWork)
//        {
//            _photoRepository = photoRepository;
//            _mapper = mapper;
//        }

//        public async Task<CustomResponseDto<List<ProductDto>>> GetPhotosWithProduct()
//        {
//            var photos = await _photoRepository.GetPhotosWithProduct();

//            var photosDto = _mapper.Map<List<ProductDto>>(photos);
//            return CustomResponseDto<List<ProductPhotoDto>>.Succes(200, photosDto);
//        }
//    }
//}
