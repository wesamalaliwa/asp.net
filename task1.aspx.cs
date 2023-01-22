using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NETEntityFramework
{
    public partial class task1 : System.Web.UI.Page
    {
        Entities ww = new Entities();
        private string fileName;

        public class myclass
        {
            public string CustomerIDs { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    var x = from s in ww.Cities select s;
            //    DropDownList1.DataSource = x.ToList();
            //    DropDownList1.DataTextField = "CityName";
            //    DropDownList1.DataValueField = "CityId";
            //    DropDownList1.DataBind();
            //}

            //var x1=from s in ww.Cities
            //       join a in ww.Customers
            //      on s.CityId equals a.IDcITY
            //      select new {s.CityName,a.CustomerNames,a.CustomerPhone,a.CustomerEmail,a.CustomerPhoto };

            ////var b = (from p in ww.Customers
            ////         join e1 in ww.Cities
            ////         on p.IDcITY equals e1.CityId

            ////         select new
            ////         {
            ////            p.CustomerIDs,
            ////           p.CustomerNames,
            ////            p.CustomerAges,
            ////             p.CustomerPhone,
            ////             p.CustomerEmail,
            ////               e1.CityName,

            ////             CustomerPhoto7 = p.CustomerPhoto
            ////         }).ToList();


            //GridView1.DataSource = x1.ToList();
            //GridView1.DataBind();

            //var dataa = ww.Customers.ToList();


            //GridView1.DataSource = dataa;
            //GridView1.DataBind();

            if (!IsPostBack)
            {
                var x = from s in ww.Cities select s;
                DropDownList1.DataSource = x.ToList();
                DropDownList1.DataTextField = "CityName";
                DropDownList1.DataValueField = "CityId";
                DropDownList1.DataBind();
            }

            var x1 = from s in ww.Cities
                     join a in ww.Customers
                     on s.CityId equals a.IDcITY
                     select new { s.CityName, a.CustomerNames, a.CustomerPhone, a.CustomerEmail, a.CustomerPhoto, a.CustomerAges , a.CustomerIDs /*, ImageUrl = "~/Images/" + a.CustomerPhoto */};

            GridView1.DataSource = x1.ToList();
            GridView1.DataBind();

            //if (GridView1 != null && GridView1.Columns.Count > 0)
            //{
            //    GridView1.Columns[0].HeaderText = "Name";
            //}

            //Count
            var count = (from pd in ww.Customers select pd).Count();
            Label1.Text = count.ToString();

            //Avg
            var n = ww.Customers.ToList();
            var avg = n.Average(s => s.CustomerAges);
            Label2.Text = avg.ToString();

            //Max
            var max = n.Max(s => s.CustomerAges);
            Label3.Text = max.ToString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            fileName = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("~/Images/") + fileName);
            //FileUpload1.SaveAs(Server.MapPath("~/Images/") + fileName);

            //Customer insertTest = new Customer();
            ////Guid guid= Guid.NewGuid();
            ////insertTest.CustomerNames = guid.ToString();
            //insertTest.CustomerNames = TextBox1.Text;
            //insertTest.CustomerAges = Convert.ToInt32(TextBox2.Text);
            //insertTest.CustomerEmail = TextBox3.Text;
            //insertTest.CustomerPhone = Convert.ToInt32( TextBox4.Text);
            //insertTest.IDcITY = int.Parse(DropDownList1.SelectedValue);
            //insertTest.CustomerCity = (DropDownList1.SelectedValue);
            //insertTest.CustomerPhoto = FileUpload1.FileName;


            //ww.Customers.Add(insertTest);
            //ww.SaveChanges();
            //Customer insertTest = new Customer();
            //insertTest.CustomerNames = TextBox1.Text;
            //insertTest.CustomerAges = Convert.ToInt32(TextBox2.Text);
            //insertTest.CustomerEmail = TextBox3.Text;
            //insertTest.CustomerPhone = Convert.ToInt32(TextBox4.Text);
            //insertTest.IDcITY = Convert.ToInt32(DropDownList1.SelectedValue);
            //insertTest.CustomerCity = (DropDownList1.SelectedValue);
            //insertTest.CustomerPhoto = "~/Images/"+FileUpload1.FileName;
            //ww.Customers.Add(insertTest);
            //ww.SaveChanges();
            Customer insertTest = new Customer();
            insertTest.CustomerNames = TextBox1.Text;
            insertTest.CustomerAges = Convert.ToInt32(TextBox2.Text);
            insertTest.CustomerEmail = TextBox3.Text;
            insertTest.CustomerPhone = Convert.ToInt32(TextBox4.Text);
            insertTest.IDcITY = int.Parse(DropDownList1.SelectedValue);
            insertTest.CustomerCity = (DropDownList1.SelectedValue);
            insertTest.CustomerPhoto = fileName;
            ww.Customers.Add(insertTest);
            ww.SaveChanges();
            Response.Redirect("/task1.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
       

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (GridView1 != null && GridView1.Columns.Count > 0)
            //{
            //    GridView1.Columns[0].HeaderText = "Name";
            //}

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var imagePath = (e.Row.DataItem as dynamic).CustomerPhoto;
                var image = new Image();
                image.ImageUrl = "~/Images/" + imagePath;
                image.Height = 100;
                image.Width = 100;
                e.Row.Cells[4].Controls.Add(image);
            }

           
        }
        protected void searchButton_Click(object sender, EventArgs e)
        {
            // Get the search query from the textbox
            string searchQuery = searchTextbox.Text;
            if (searchQuery != "")
            {
                // Use LINQ to filter the data based on the search query
                var filteredData = from s in ww.Cities
                                   join a in ww.Customers
                                   on s.CityId equals a.IDcITY
                                   where a.CustomerNames.Contains(searchQuery)
                                   select new { s.CityName, a.CustomerNames, a.CustomerPhone, a.CustomerEmail, a.CustomerPhoto, a.CustomerAges, a.CustomerIDs };

                // Bind the filtered data to the GridView
                GridView1.DataSource = filteredData.ToList();
                GridView1.DataBind();
            }
        }




    }
}

