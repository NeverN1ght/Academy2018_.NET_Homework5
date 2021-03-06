﻿using System.Collections.Generic;
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
    public class DeparturesService: IService<DepartureDto>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<Departure> _validator;

        public DeparturesService(
            UnitOfWork unitOfWork,
            IMapper mapper,
            AbstractValidator<Departure> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public IEnumerable<DepartureDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Departure>, IEnumerable<DepartureDto>>(
                _unitOfWork.Departures.Get());
        }

        public DepartureDto GetById(object id)
        {
            var response = _mapper.Map<Departure, DepartureDto>(
                _unitOfWork.Departures.Get(id));

            if (response == null)
            {
                throw new NotExistException();
            }

            return response;
        }

        public object Add(DepartureDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            var model = _mapper.Map<DepartureDto, Departure>(dto);
            var validationResult = _validator.Validate(model);

            if (validationResult.IsValid)
            {
                return _unitOfWork.Departures.Create(model);
            }

            throw new ValidationException(validationResult.Errors);
        }

        public void Update(object id, DepartureDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            if (_unitOfWork.Departures.IsExist(id))
            {
                var model = _mapper.Map<DepartureDto, Departure>(dto);
                var validationResult = _validator.Validate(model);

                if (validationResult.IsValid)
                {
                    _unitOfWork.Departures.Update(id, model);

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
            if (_unitOfWork.Departures.IsExist(id))
            {
                _unitOfWork.Departures.Delete(id);

                _unitOfWork.SaveChanges();
            }
            else
            {
                throw new NotExistException();
            }
        }
    }
}
