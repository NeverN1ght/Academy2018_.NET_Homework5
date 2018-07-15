using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework5.Core.Abstractions;
using Academy2018_.NET_Homework5.Infrastructure.Models;
using Academy2018_.NET_Homework5.Infrastructure.UnitOfWork;
using Academy2018_.NET_Homework5.Shared.DTOs;
using Academy2018_.NET_Homework5.Shared.Exceptions;
using AutoMapper;
using FluentValidation;

namespace Academy2018_.NET_Homework5.Core.Services
{
    public class AirplanesService: IService<AirplaneDto>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<Airplane> _validator;

        public AirplanesService(
            UnitOfWork unitOfWork, 
            IMapper mapper,
            AbstractValidator<Airplane> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public IEnumerable<AirplaneDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Airplane>, IEnumerable<AirplaneDto>>(
                _unitOfWork.Airplanes.Get());
        }

        public AirplaneDto GetById(object id)
        {
            var response = _mapper.Map<Airplane, AirplaneDto>(
                _unitOfWork.Airplanes.Get(id));

            if (response == null)
            {
                throw new NotExistException();
            }

            return response;
        }

        public object Add(AirplaneDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            var model = _mapper.Map<AirplaneDto, Airplane>(dto);
            var validationResult = _validator.Validate(model);

            if (validationResult.IsValid)
            {
                return _unitOfWork.Airplanes.Create(model);
            }

            throw new ValidationException(validationResult.Errors);
        }

        public void Update(object id, AirplaneDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            if (_unitOfWork.Airplanes.IsExist(id))
            {
                var model = _mapper.Map<AirplaneDto, Airplane>(dto);
                var validationResult = _validator.Validate(model);

                if (validationResult.IsValid)
                {
                    _unitOfWork.Airplanes.Update(id, model);

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
            if (_unitOfWork.Airplanes.IsExist(id))
            {
                _unitOfWork.Airplanes.Delete(id);

                _unitOfWork.SaveChanges();
            }
            else
            {
                throw new NotExistException();
            }
        }
    }
}
