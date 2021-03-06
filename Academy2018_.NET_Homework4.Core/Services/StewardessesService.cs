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
    public class StewardessesService: IService<StewardesseDto>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<Stewardesse> _validator;

        public StewardessesService(
            UnitOfWork unitOfWork, 
            IMapper mapper,
            AbstractValidator<Stewardesse> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public IEnumerable<StewardesseDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Stewardesse>, IEnumerable<StewardesseDto>>(
                _unitOfWork.Stewardesses.Get());
        }

        public StewardesseDto GetById(object id)
        {
            var response = _mapper.Map<Stewardesse, StewardesseDto>(
                _unitOfWork.Stewardesses.Get(id));

            if (response == null)
            {
                throw new NotExistException();
            }

            return response;
        }

        public object Add(StewardesseDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            var model = _mapper.Map<StewardesseDto, Stewardesse>(dto);
            var validationResult = _validator.Validate(model);

            if (validationResult.IsValid)
            {
                return _unitOfWork.Stewardesses.Create(model);
            }

            throw new ValidationException(validationResult.Errors);
        }

        public void Update(object id, StewardesseDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            if (_unitOfWork.Stewardesses.IsExist(id))
            {
                var model = _mapper.Map<StewardesseDto, Stewardesse>(dto);
                var validationResult = _validator.Validate(model);

                if (validationResult.IsValid)
                {
                    _unitOfWork.Stewardesses.Update(id, model);

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
            if (_unitOfWork.Stewardesses.IsExist(id))
            {
                _unitOfWork.Stewardesses.Delete((int)id);

                _unitOfWork.SaveChanges();
            }
            else
            {
                throw new NotExistException();
            }
        }
    }
}

