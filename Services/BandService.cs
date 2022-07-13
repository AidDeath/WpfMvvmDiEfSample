using Microsoft.EntityFrameworkCore;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMvvmDiEfSample.Data;
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
