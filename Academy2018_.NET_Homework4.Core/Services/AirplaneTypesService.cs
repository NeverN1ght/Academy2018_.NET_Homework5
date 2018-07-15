using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework5.Core.Abstractions;
using Academy2018_.NET_Homework5.Infrastructure.Abstractions;
using Academy2018_.NET_Homework5.Infrastructure.Models;
using Academy2018_.NET_Homework5.Infrastructure.UnitOfWork;
using Academy2018_.NET_Homework5.Shared.DTOs;
using Academy2018_.NET_Homework5.Shared.Exceptions;
using AutoMapper;
using FluentValidation;

namespace Academy2018_.NET_Homework5.Core.Services
{
    public class AirplaneTypesService: IService<AirplaneTypeDto>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<AirplaneType> _validator;

        public AirplaneTypesService(
            UnitOfWork unitOfWork,
            IMapper mapper,
            AbstractValidator<AirplaneType> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public IEnumerable<AirplaneTypeDto> GetAll()
        {
            return _mapper.Map<IEnumerable<AirplaneType>, IEnumerable<AirplaneTypeDto>>(
                _unitOfWork.AirplaneTypes.Get());
        }

        public AirplaneTypeDto GetById(object id)
        {
            var response = _mapper.Map<AirplaneType, AirplaneTypeDto>(
                _unitOfWork.AirplaneTypes.Get(id));

            if (response == null)
            {
                throw new NotExistException();
            }

            return response;
        }

        public object Add(AirplaneTypeDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            var model = _mapper.Map<AirplaneTypeDto, AirplaneType>(dto);
            var validationResult = _validator.Validate(model);

            if (validationResult.IsValid)
            {
                return _unitOfWork.AirplaneTypes.Create(model);
            }

            throw new ValidationException(validationResult.Errors);
        }

        public void Update(object id, AirplaneTypeDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            if (_unitOfWork.AirplaneTypes.IsExist(id))
            {
                var model = _mapper.Map<AirplaneTypeDto, AirplaneType>(dto);
                var validationResult = _validator.Validate(model);

                if (validationResult.IsValid)
                {
                    _unitOfWork.AirplaneTypes.Update(id, model);

                    _unitOfWork.SaveChanges();
                }
                else
                {
                    throw new ValidationException(validationResult.Errors);
                }
            }
            else
            {
                throw new NotExistException();
            }        
        }

        public void Delete(object id)
        {
            if (_unitOfWork.AirplaneTypes.IsExist(id))
            {
                _unitOfWork.AirplaneTypes.Delete(id);

                _unitOfWork.SaveChanges();
            }
            else
            {
                throw new NotExistException();
            }
        }
    }
}
