using CityBikeNYC.BR;
using CityBikeNYC.Data;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CityBikeNYC
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Declaración de instancias
        private readonly IStationBeanAdapter adapter;
        private readonly IAutoMapper mapper;

        private StationBeanQuery query;
        private ObservableCollection<StationBasicInfo> stationBasicList;
        private ObservableCollection<StationExtendedInfo> stationExtendedList;

        private StationBasicInfo selectedStation;
        private StationExtendedInfo selectedStationExtendedInfo;

        private RelayCommand _dgStationSelectedItemChangedCommand;
        private RelayCommand _gridSplitterMouseEnterCommand;
        private RelayCommand _gridSplitterMouseLeaveCommand;
        #endregion

        #region Declaración/asignación de variables
        public StationBeanQuery Query
        {
            get { return query; }
            set { query = value; }
        }
        public ObservableCollection<StationBasicInfo> StationBasicList
        {
            get { return stationBasicList; }
            set { stationBasicList = value; }
        }
        public ObservableCollection<StationExtendedInfo> StationExtendedList
        {
            get { return stationExtendedList; }
            set { stationExtendedList = value; }
        }
        public StationBasicInfo SelectedStation
        {
            get { return selectedStation; }
            set
            {
                if (selectedStation == value)
                    return;

                selectedStation = value;
                OnPropertyChanged();
            }
        }
        public StationExtendedInfo SelectedStationExtendedInfo
        {
            get { return selectedStationExtendedInfo; }
            set
            {
                if (selectedStationExtendedInfo == value)
                    return;

                selectedStationExtendedInfo = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand dgStationSelectedItemChangedCommand
        {
            get
            {
                return _dgStationSelectedItemChangedCommand ?? (_dgStationSelectedItemChangedCommand = new RelayCommand(o => OnStationChanged(), o => true));
            }
        }
        public RelayCommand GridSplitterMouseEnterCommand
        {
            get
            {
                return _gridSplitterMouseEnterCommand ?? (_gridSplitterMouseEnterCommand = new RelayCommand(o => OnGridSplitterMouseEnter(), o => true));
            }
        }
        public RelayCommand GridSplitterMouseLeaveCommand
        {
            get
            {
                return _gridSplitterMouseLeaveCommand ?? (_gridSplitterMouseLeaveCommand = new RelayCommand(o => OnGridSplitterMouseLeave(), o => true));
            }
        }
        #endregion

        #region Constructor
        public MainWindowViewModel(IStationBeanAdapter adapter, IAutoMapper mapper)
        {
            this.adapter = adapter;
            this.mapper = mapper;

            try
            {
                Query = adapter.GetStationBeanList();

                StationBasicList = new ObservableCollection<StationBasicInfo>();
                StationExtendedList = new ObservableCollection<StationExtendedInfo>();

                foreach(StationBean sb in Query.stationBeanList)
                {
                    StationBasicList.Add(mapper.Map<StationBasicInfo>(sb));
                    StationExtendedList.Add(mapper.Map<StationExtendedInfo>(sb));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Métodos
        private void OnStationChanged()
        {
            try
            {
                if(SelectedStation != null)
                    SelectedStationExtendedInfo = mapper.Map<StationExtendedInfo>(Query.stationBeanList.FirstOrDefault(x => x.id.Equals(SelectedStation.id)));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void OnGridSplitterMouseEnter()
        {
            Mouse.OverrideCursor = Cursors.SizeWE;
        }
        private void OnGridSplitterMouseLeave()
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }
        #endregion
    }
}
