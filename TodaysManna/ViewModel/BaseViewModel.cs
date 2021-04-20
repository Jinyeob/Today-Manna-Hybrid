﻿using TodaysManna.Services;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TodaysManna.ViewModel
{
    public class BaseViewModel : ObservableObject { }

    public class PageBaseViewModel : BaseViewModel
    {
        public PermissionService _permissionService;

        public PageBaseViewModel()
        {
            _permissionService = new PermissionService();
            Connectivity.ConnectivityChanged += ConnectivityOnConnectivityChanged;
            IsNotConnected = Connectivity.NetworkAccess != NetworkAccess.Internet;
        }

        // 인터넷 연결 상태가 변경되었을때
        private void ConnectivityOnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsNotConnected = e.NetworkAccess != NetworkAccess.Internet;
        }

        public INavigation Navigation { get; set; }

        private bool _isNotConnected;
        public bool IsNotConnected
        {
            get => _isNotConnected;
            set => SetProperty(ref _isNotConnected, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
    }
}