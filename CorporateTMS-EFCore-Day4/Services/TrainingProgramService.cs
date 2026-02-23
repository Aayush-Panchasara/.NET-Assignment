using CorporateTMS_EFCore_Day4.Repository.Model;
using CorporateTMS_EFCore_Day4.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Services
{
    internal class TrainingProgramService
    {
        private TrainingProgramRepository _trRepo;
        public TrainingProgramService(TrainingProgramRepository trRepo)
        {
            _trRepo = trRepo;
        }

        public void CreateTrainingProgram(string title, int duration, DateTime startDate,int trainerId)
        {
            var TrainingProgram = new TrainingProgram() {Title=title, Duration=duration,StartDate=startDate, TrainerId=trainerId };

            _trRepo.Add(TrainingProgram);

        }

        public void DeleteTrainingProgram(int id)
        {
            _trRepo.Delete(id);
        }

        public List<TrainingProgram> GetAllTrainingProgram()
        {
            return _trRepo.GetAll();
        }
    }
}
