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
    public class PilotsService: IService<PilotDto>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<PilotDto> _validator;

        public PilotsService(
            UnitOfWork unitOfWork, 
            IMapper mapper, 
            AbstractValidator<PilotDto> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public IEnumerable<PilotDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Pilot>, IEnumerable<PilotDto>>(
                _unitOfWork.Pilots.Get());
        }

        public PilotDto GetById(object id)
        {
            var response = _mapper.Map<Pilot, PilotDto>(
                _unitOfWork.Pilots.Get().FirstOrDefault(p => p.Id == (int)id));

            if (response == null)
            {
                throw new NotExistException();
            }

            return response;
        }

        public object Add(PilotDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            var validationResult = _validator.Validate(dto);

            if (validationResult.IsValid)
            {
                return _unitOfWork.Pilots.Create(
                    _mapper.Map<PilotDto, Pilot>(dto));
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }          
        }

        public void Update(object id, PilotDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            if (_unitOfWork.Pilots.IsExist(id))
            {
                var validationResult = _validator.Validate(dto);

                if (validationResult.IsValid)
                {
                    _unitOfWork.Pilots.Update((int)id,
                        _mapper.Map<PilotDto, Pilot>(dto));

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
            if (_unitOfWork.Pilots.IsExist(id))
            {
                _unitOfWork.Pilots.Delete((int)id);

                _unitOfWork.SaveChanges();
            }
            else
            {
                throw new NotExistException();
            }
        }
    }
}
