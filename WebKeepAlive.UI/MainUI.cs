using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebKeepAlive.Core.Entities;
using WebKeepAlive.Core.Interfaces;

namespace WebKeepAlive.UI;
public partial class MainUI : Form
{

    private readonly IEndpointRepository _endPointRepository;
    private readonly IWorkerService _workerService;
    private BindingList<Endpoint> items;

    public MainUI(IEndpointRepository endPointRepository, IWorkerService workerService)
    {
        InitializeComponent();
        _endPointRepository = endPointRepository;
        _workerService = workerService;
    }

    private async void MainUI_Load(object sender, EventArgs e)
    {
        // Get all endpoints from database and bind them
        var endpoints = await _endPointRepository.GetAllEndpointsAsync();
        items = new BindingList<Endpoint>(endpoints.ToList());
        data_grid.DataSource = items;

        // set label state and buttons
        if (_workerService.IsRunning())
        {
            state_lbl.Text = "Running";
            state_lbl.ForeColor = Color.Green;
            
            // disable start button
            start_btn.Enabled = false;
        }
        else
        {
            state_lbl.Text = "Stopped";
            state_lbl.ForeColor = Color.Red;

            // disable stop button
            stop_btn.Enabled = false;
        }

    }
    
    private async void add_btn_ClickAsync(object sender, EventArgs e)
    {
        var newUrl = url_txt_box.Text;
        await _endPointRepository
            .AddEndpointAsync(new Endpoint { EndpointUrl = newUrl });

        MainUI_Load(sender, e);
    }

    private void data_grid_SelectionChanged(object sender, EventArgs e)
    {
        if (data_grid.SelectedRows.Count > 0)
        {
            btn_delete.Enabled = true;

            int selectedIndex = data_grid.SelectedRows[0].Index;
            // Get the selected item's id
            string selectedUrl = data_grid.Rows[selectedIndex].Cells["EndpointUrl"].Value.ToString();
            this.url_txt_box.Text = selectedUrl;
            
        }
        else
        {
            btn_delete.Enabled = false;
        }


    }

    private async void btn_delete_ClickAsync(object sender, EventArgs e)
    {
        if (data_grid.SelectedRows.Count > 0)
        {
            int selectedIndex = data_grid.SelectedRows[0].Index;

            // Get the selected item's id
            int selectedId = Convert.ToInt32(data_grid.Rows[selectedIndex].Cells["Id"].Value);

            await _endPointRepository.DeleteEndpointAsync(selectedId);

            // Remove the item from the DataGridView
            data_grid.Rows.RemoveAt(selectedIndex);
        }
    }

    private void start_btn_Click(object sender, EventArgs e)
    {
        // start the service
        _workerService.Start();

        // set label state
        state_lbl.Text = "Running";
        state_lbl.ForeColor = Color.Green;

        // disable start button
        start_btn.Enabled = false;

        // enable stop button
        stop_btn.Enabled = true;


    }

    private void stop_btn_Click(object sender, EventArgs e)
    {
        // stop the service 
        _workerService.Stop();

        // set label state
        state_lbl.Text = "Stopped";
        state_lbl.ForeColor = Color.Red;

        // disable stop button
        stop_btn.Enabled = false;

        // enable start button
        start_btn.Enabled = true;
    }

    private void refresh_btn_Click(object sender, EventArgs e)
    {
        Debug.WriteLine("REFRESHINGGGGG");
        this.MainUI_Load(sender, e);
    }
}
