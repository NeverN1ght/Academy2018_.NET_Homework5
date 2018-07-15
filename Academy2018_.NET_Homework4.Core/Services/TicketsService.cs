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
    public class TicketsService: IService<TicketDto>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<Ticket> _validator;

        public TicketsService(
            UnitOfWork unitOfWork, 
            IMapper mapper,
            AbstractValidator<Ticket> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public IEnumerable<TicketDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDto>>(
                _unitOfWork.Tickets.Get());
        }

        public TicketDto GetById(object id)
        {
            var response = _mapper.Map<Ticket, TicketDto>(
                _unitOfWork.Tickets.Get(id));

            if (response == null)
            {
                throw new NotExistException();
            }

            return response;
        }

        public object Add(TicketDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            var model = _mapper.Map<TicketDto, Ticket>(dto);
            var validationResult = _validator.Validate(model);

            if (validationResult.IsValid)
            {
                return _unitOfWork.Tickets.Create(model);
            }

            throw new ValidationException(validationResult.Errors);
        }

        public void Update(object id, TicketDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            if (_unitOfWork.Tickets.IsExist(id))
            {
                var model = _mapper.Map<TicketDto, Ticket>(dto);
                var validationResult = _validator.Validate(model);

                if (validationResult.IsValid)
                {
                    _unitOfWork.Tickets.Update(id, model);

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
            if (_unitOfWork.Tickets.IsExist(id))
            {
                _unitOfWork.Tickets.Delete(id);

                _unitOfWork.SaveChanges();
            }
            else
            {
                throw new NotExistException();
            }
        }
    }
}
