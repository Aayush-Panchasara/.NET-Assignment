using CorporateTMS_EFCore_Day4.Repository.Model;
using CorporateTMS_EFCore_Day4.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Services
{
    internal class EnrollmentService
    {
        private EnrollmentRepository _enrRepo;
        public EnrollmentService(EnrollmentRepository enrRepo)
        {
            _enrRepo = enrRepo;
        }

        public void EnrollEmployee(int employeeId, int trainingId, DateTime enrollmentdate)
        {
            var Enrollment = new Enrollment() {EmployeeId=employeeId, TrainerProgramId=trainingId, EnrollDate=enrollmentdate};

            _enrRepo.Add(Enrollment);

        }

        public void UpdateScore(int employeeId, int trainingId, int newPerformance) {
            var Enrollment = new Enrollment() { EmployeeId = employeeId, TrainerProgramId = trainingId, PerformanceScore = newPerformance };

            _enrRepo.Update(Enrollment);
        
        }
    }
}
