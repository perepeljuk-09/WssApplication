using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WssApplication.Domain.Entities;
using WssApplication.Infrastructure.Db;
using WssApplication.Infrastructure.ServiceInterfaces;
using WssApplication.Shared.Dtos.Department;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WssApplication.Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ILogger<DepartmentService> _logger;
        private readonly PgContext _pgContext;
        private readonly IMapper _mapper;

        public DepartmentService(
            ILogger<DepartmentService> logger,
            PgContext pgContext,
            IMapper mapper)
        {
            _logger = logger;
            _pgContext = pgContext;
            _mapper = mapper;
        }

        public async Task<DepartmentDto> GetDepartmentById(int departmentId)
        {
            // Получаем департамент по Айди
            throw new NotImplementedException();
        }

        public async Task<ICollection<DepartmentDto>> GetDepartmentsByCompanyId(int companyId)
        {
            // Получаем все департаменты по Айди компании
            throw new NotImplementedException();
        }
        public async Task<DepartmentDto> CreateDepartment(DepartmentCreationDto departmentCreationDto)
        {
            // Создаём департамент
            var newDepartment = _mapper.Map<Department>(departmentCreationDto);

            // Получаем количество текущих рабочих департаментов у компании
            var countCurrentDepartment = await _pgContext.Departments
                .Where(x => x.DeletedDate == null && x.CompanyId == departmentCreationDto.CompanyId)
                .CountAsync();

            // устанавливаем позицию для вывода в UI
            newDepartment.Position = countCurrentDepartment + 1;

            await _pgContext.AddAsync(newDepartment);
            await _pgContext.SaveChangesAsync();

            var result = _mapper.Map<DepartmentDto>(newDepartment);
            return result;
        }

        public Task<DepartmentDto> UpdateDepartment(DepartmentUpdateDto departmentUpdateDto, int departmentId)
        {
            // Обновляем данные департамента
            throw new NotImplementedException();
        }

        public async Task DeleteDepartment(int departmentId)
        {
            // Удаляем департамент

            var department = await _pgContext.Departments
                .FirstOrDefaultAsync(x => x.Id == departmentId);

            if (department == null) throw new Exception($"Not found department with id {departmentId}");

            var departments = await _pgContext.Departments
                .Where(x => x.CompanyId == department.CompanyId)
                .OrderBy(x => x.Position)
                .ToListAsync();


            var isLastPosition = department.Position == departments.Count;
            departments.Remove(department);

            // Если удаляем не последнюю позицию, то нужно пересчитать позиции.
            if (!isLastPosition)
            {
                UpdatePositions(departments);
            }

            await _pgContext.SaveChangesAsync();
        }

        public async Task Move(DepartmentMoveDto departmentMoveDto)
        {
            // Перемещаем департамент

            var departments = await _pgContext.Departments
                .OrderBy(d => d.Position)
                .ToListAsync();


            // Находим перемещаемый департамент
            var departmentToMove = departments.FirstOrDefault(d => d.Id == departmentMoveDto.DepartmentId);
            if (departmentToMove == null)
                throw new Exception($"Not found department with id {departmentMoveDto.DepartmentId}");


            // Удаляем департамент из списка
            departments.Remove(departmentToMove);

            // Вставляем департамент
            departments.Insert(departmentMoveDto.ToPosition, departmentToMove);

            // Обновляем позиции
            UpdatePositions(departments);

            await _pgContext.SaveChangesAsync();
        }

        private void UpdatePositions(List<Department> departments)
        {
            for (int i = 0; i < departments.Count; i++)
            {
                departments[i].Position = i + 1; 
            }
        }
    }
}
