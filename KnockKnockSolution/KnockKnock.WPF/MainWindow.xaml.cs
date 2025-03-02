using RequestServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KnockKnock.WPF
{
    public partial class MainWindow : Window
    {
        private readonly RequestServiceClient _service = new RequestServiceClient();

        public MainWindow()
        {
            InitializeComponent();
            LoadRequests();
            StartAutoRefresh();
        }

        // Fetch latest requests from the WCF service
        private async void LoadRequests()
        {
            try
            {
                var requests = await _service.CheckForRequestsAsync();
                RequestsList.ItemsSource = requests; // ✅ Ensure UI updates immediately
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching requests: " + ex.Message);
            }
        }

        // Auto-refresh every 10 seconds to keep UI updated
        private async void StartAutoRefresh()
        {
            while (true)
            {
                await Task.Delay(10000);
                LoadRequests();
            }
        }

        private async void Approve_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button?.DataContext is Request selectedRequest)
            {
                if (selectedRequest.Status == 1)
                {
                    MessageBox.Show("Request is already approved.");
                    return; // ✅ Prevent re-approval
                }

                bool success = await _service.UpdateRequestAsync(selectedRequest.RequestID, true);
                if (success)
                {
                    selectedRequest.Status = 1; // ✅ Update UI immediately
                    RequestsList.Items.Refresh(); // ✅ Ensure UI reflects the change
                }
                else
                {
                    MessageBox.Show("Failed to approve request.");
                }
            }
        }

        private async void Reject_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button?.DataContext is Request selectedRequest)
            {
                if (selectedRequest.Status == 1)
                {
                    MessageBox.Show("Approved requests cannot be rejected.");
                    return; // ✅ Prevent rejecting an already approved request
                }

                bool success = await _service.UpdateRequestAsync(selectedRequest.RequestID, false);
                if (success)
                {
                    selectedRequest.Status = 2; // ✅ Update UI immediately
                    RequestsList.Items.Refresh(); // ✅ Ensure UI reflects the change
                }
                else
                {
                    MessageBox.Show("Failed to reject request.");
                }
            }
        }
    }
}
