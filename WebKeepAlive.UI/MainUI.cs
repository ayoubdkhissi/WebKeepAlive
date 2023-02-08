using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    private BindingList<Endpoint> items;
    
    public MainUI(IEndpointRepository endPointRepository)
    {
        InitializeComponent();
        _endPointRepository = endPointRepository;
    }

    private async void MainUI_Load(object sender, EventArgs e)
    {
        var endpoints = await _endPointRepository.GetAllEndpointsAsync();
        items = new BindingList<Endpoint>(endpoints.ToList());

        data_grid.DataSource = items;
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
}
