﻿using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WpfMvvmDiEfSample.Data;
using WpfMvvmDiEfSample.Helpers;
using WpfMvvmDiEfSample.Models;

namespace WpfMvvmDiEfSample.Services
{
    public class BandService
    {
        private readonly SampleContext _database;
        public BandService(SampleContext database)
        {
            _database = database;
        }

        public ObservableCollection<Band> GetAllBands()
        {
            ObservableRangeCollection<Band> bands = new(_database.Bands);
            return bands;
        }

        public async Task<ObservableCollection<Band>> GetAllBandsAsync()
        {
            ObservableRangeCollection<Band> bands = new( await _database.Bands.ToListAsync());

            return bands;
        }
    }
}
