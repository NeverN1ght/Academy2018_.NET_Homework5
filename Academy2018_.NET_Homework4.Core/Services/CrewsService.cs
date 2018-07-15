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
    public class CrewsService: IService<CrewDto>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<CrewDto> _validator;

        public CrewsService(
            UnitOfWork unitOfWork,
            IMapper mapper,
            AbstractValidator<CrewDto> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public IEnumerable<CrewDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Crew>, IEnumerable<CrewDto>>(
                _unitOfWork.Crews.Get());
        }

        public CrewDto GetById(object id)
        {
            var response = _mapper.Map<Crew, CrewDto>(
                _unitOfWork.Crews.Get().FirstOrDefault(c => c.Id == (int)id));

            if (response == null)
            {
                throw new NotExistException();
            }

            return response;
        }

        public object Add(CrewDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            var validationResult = _validator.Validate(dto);

            if (validationResult.IsValid)
            {
                return _unitOfWork.Crews.Create(
                    _mapper.Map<CrewDto, Crew>(dto));
            }

            throw new ValidationException(validationResult.Errors);
        }

        public void Update(object id, CrewDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            if (_unitOfWork.Crews.IsExist(id))
            {
                var validationResult = _validator.Validate(dto);

                if (validationResult.IsValid)
                {
                    _unitOfWork.Crews.Update((int)id,
                        _mapper.Map<CrewDto, Crew>(dto));

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
            if (_unitOfWork.Crews.IsExist(id))
            {
                _unitOfWork.Crews.Delete((int)id);

                _unitOfWork.SaveChanges();
            }
            else
            {
                throw new NotExistException();
            }
        }
    }
}
