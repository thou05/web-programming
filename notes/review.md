Created: 202511251344

Tags: 

# AJAX
## Câu 5
### Regular 
- Regular expression để validate UnitPrice chỉ có thể nhập số và giá trị phải >100.
	```c#
	//string
	[Required]
    [RegularExpression(@"^(10[1-9]|1[1-9]\d|[2-9]\d{2,})$", 
        ErrorMessage = "UnitPrice phải là số và lớn hơn 100")]
    public string UnitPrice { get; set; }

	//so 
	[Range(101, double.MaxValue, ErrorMessage = "UnitPrice phải là số và lớn hơn 100")]
	public double UnitPrice { get; set; }
	```
-  Giá phải là số và năm trong giới hạn 100 đến 5000. 
	```c#
	[Range(100, 5000, ErrorMessage = "gia tu 100-5000")]
	public decimal? Gia { get; set; }
	```

- Tên file ảnh phải có đuôi: .jpg | .png | .gif | .tiff
	```c#
	[RegularExpression(@".*\.(jpg|png|gif|tiff)$", ErrorMessage = "File kieu .jpg|.png|.gif|.tiff")]
	public string? Anh { get; set; }
	```

- RegularExpression để tạo Annotation validate Email 
	```c#
	[RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Email không hợp lệ")]
	public string Email { get; set; } = null!;
	```

-  Annotation để validate RePassword phải trùng Password 
	```c#
	public string Password { get; set; } = null!;

	[Compare("Password", ErrorMessage = "Phai trung mat khau")]
	public string RePassword { get; set; } = null!;
	```

- Regular expression để tạo Annotation validate Id phải theo đúng định dạng XX0000 trong đó XX là 2 ký tự hoa, 0000 là 4 chữ số. 
	```c#
	[RegularExpression(@"^[A-Z]{2}\d{4}$", ErrorMessage = "ID phải có định dạng XX0000 (Ví dụ: AB1234)")]
	public string Id { get; set; } = null!;
	```

- Text bắt đầu bằng chữ cái 
	```c#
	[Display(Name = "Tên sản phẩm")] 
 	[Required(ErrorMessage = "Tên sản phẩm không được để trống")] 
 	[RegularExpression(@"^[a-zA-ZÀ-ỹ][a-zA-Z0-9À-ỹ\s]*$", ErrorMessage = "Tên sản phẩm phải bắt đầu bằng chữ cái")]
	```

- Chữ số, giá:
	```c#
	[Display(Name = "Giá nhập")] 
	[DisplayFormat(DataFormatString = "{0:N0}")] 
	[RegularExpression(@"^[0-9]+$", ErrorMessage = "Giá nhập chỉ được nhập số")]

	[Range(0, long.MaxValue, ErrorMessage = "Giá nhập phải lớn hơn hoặc bằng 0")]

	//Nằm khoảng từ 100 đến 5000 
	(100|[1-9]\d{2,3}|[1-4]\d{3}|5000) 
	```

- lab
	```c#
	[RegularExpression(@"[A-Za-z0-9._%+-]+@gmail\.com$",
                            ErrorMessage = "Email phải có đuôi @gmail.com")]
	public string? Email { get; set; }

	[Required(ErrorMessage = "Ngày sinh phải được nhập")]
	//[Range(typeof(DateTime), "1963-01-01", "2005-12-31")]
	[DataType(DataType.Date)]
	public DateTime DateOfBirth { get; set; }

	[Required(ErrorMessage = "Điểm phải được nhập")]
	[Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng 0.0 đến 10.0")]
	[Display(Name = "Điểm")]
	public double Score { get; set; }

	[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$", 
            ErrorMessage = "Mật khẩu phải từ 8 ký tự trở lên, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt.")]
	[DataType(DataType.Password)]
	public string Password { get; set; }
	```

- slide
	```c#
	[Required(ErrorMessage= "Please enter your name.")]
	public string Name { get; set; }
	[StringLength(9, MinimumLength= 4)]
	[DataType(DataType.Password)]
	public string Password { get; set; }

	[Range(18, 60, ErrorMessage= "The age should be between 18 and 60.")]
 	public int Age { get; set; }

	[DataType(DataType.MultilineText)]
 	public string Address { get; set; }

	[ReadOnly(true)]
	public intDiscountedAmount { get; set; }
	```

## cau 2 3 4
### search

```c#
 public JsonResult LttGetNav()
 {
     var nav = _db.NavItems.ToList();
     return Json(nav);
 }

 public JsonResult LttGetTop3Products()
 {
     var products = _db.Products.OrderByDescending(p => p.UnitPrice).Take(3).ToList();
     return Json(products);
 }

 public JsonResult LttSearch(string keyword)
 {
     var products = _db.Products.Where(p => p.Name.Contains(keyword)).ToList();
     return Json(products);
 }
```

```html
<script>
	function LoadProduct(data){
		let container = $('.agile_top_brands_grids')
		container.html('');
		let itemBox = ``;
		data.forEach(item => {
					itemBox += `
						<div class="col-md-4 top_brand_left">
							<div class="hover14 column">
								<div class="agile_top_brand_left_grid">
									<div class="agile_top_brand_left_grid_pos">
										<img src="images/offer.png" alt=" " class="img-responsive">
									</div>
									<div class="agile_top_brand_left_grid1">
										<figure>
											<div class="snipcart-item block">
												<div class="snipcart-thumb">
													<a href="single.html"><img title=" " alt=" " src="images/${item.image}"></a>
													<p>${item.name}</p>
													<h4>${item.unitPrice} <span>$55.00</span></h4>
												</div>
												<div class="snipcart-details top_brand_home_details">
													<form action="#" method="post">
														<fieldset>
															<input type="hidden" name="cmd" value="_cart">
															<input type="hidden" name="add" value="1">
															<input type="hidden" name="business" value=" ">
															<input type="hidden" name="item_name" value="Fortune Sunflower Oil">
															<input type="hidden" name="amount" value="35.99">
															<input type="hidden" name="discount_amount" value="1.00">
															<input type="hidden" name="currency_code" value="USD">
															<input type="hidden" name="return" value=" ">
															<input type="hidden" name="cancel_return" value=" ">
															<input type="submit" name="submit" value="Add to cart" class="button">
														</fieldset>
													</form>
												</div>
											</div>
										</figure>
									</div>
								</div>
							</div>
						</div>
					`;
				})
				container.html(itemBox);
	}

	$(document).ready(function(){
		$('#bs-megadropdown-tabs ul').html('');
		let item = '<li><a href="#" data-id="0">Lê Thị Thảo</a></li>';
		$.ajax({
			url: 'home/LttGetNav',
			dataType: 'json',
			success: function(res){
				res.forEach(row => {
					item += `<li><a href="#" data-id="${row.id}">${row.navNameVn}</a></li>`
				})
				$('#bs-megadropdown-tabs ul').html(item);
			}
		})
	});

	$.ajax({
		url: 'home/LttGetTop3Products',
		dataType: 'json',
		success: function(res){
            LoadProduct(res);
		}
	});

	$(document).ready(function(){
		$('#btnSearch').click(function(){
			 SearchByName();
		})

		$('#txtSearch').keyup(function(){
			SearchByName();
		})
	})

	function SearchByName(){
		let key = $('#txtSearch').val();

		$.ajax({
			 url: 'home/LttSearch',
			 data: {keyword: key},
			 dataType: 'json',
			 success: function(res){
				 LoadProduct(res);
			 }
		})

	}
</script>

```

### dropdown 
```html
<script>
	function renderProduct(data){
		var container = $('.agile_top_brands_grids');
		container.html('');

		let itemBox = ``;

		data.forEach(item =>{
					itemBox += `
						<div class="col-md-3 top_brand_left">
							<div class="hover14 column">
								<div class="agile_top_brand_left_grid">
									<div class="agile_top_brand_left_grid_pos">
										<img src="images/offer.png" alt=" " class="img-responsive">
									</div>
									<div class="agile_top_brand_left_grid1">
										<figure>
											<div class="snipcart-item block">
												<div class="snipcart-thumb">
													<a href="single.html"><img title=" " alt=" " src="images/${item.image}"></a>
													<p>${item.name}</p>
													<h4>${item.unitPrice} <span>$55.00</span></h4>
												</div>
												<div class="snipcart-details top_brand_home_details">
													<form action="#" method="post">
														<fieldset>
															<input type="hidden" name="cmd" value="_cart">
															<input type="hidden" name="add" value="1">
															<input type="hidden" name="business" value=" ">
															<input type="hidden" name="item_name" value="Fortune Sunflower Oil">
															<input type="hidden" name="amount" value="35.99">
															<input type="hidden" name="discount_amount" value="1.00">
															<input type="hidden" name="currency_code" value="USD">
															<input type="hidden" name="return" value=" ">
															<input type="hidden" name="cancel_return" value=" ">
															<input type="submit" name="submit" value="Add to cart" class="button">
														</fieldset>
													</form>
												</div>
											</div>
										</figure>
									</div>
								</div>
							</div>
						</div>
					`
				})
				container.html(itemBox);
	}


	$(document).ready(function(){
		$('#country1').html('');
		item = '<option value="all"><i class="fa fa-arrow-right" aria-hidden="true"></i>Tất cả</option>';
		$.ajax({
			url: 'home/lttloadloai',
			dataType: 'json',
			success: function(res){
                console.log(res);
				res.forEach(row => {
					item += `<option value="${row.id}"><i class="fa fa-arrow-right" aria-hidden="true"></i>${row.nameVn}</option>`
				})
				$('#country1').html(item);
			}
		})

		$.ajax({
			url: 'home/LttLoadSp',
			dataType: 'json',
			success: function(res){
				renderProduct(res);
			}
		});
	});

</script>


<script>
	$(document).on('change', '#country1', function(e){
		let selectedCate = $(this).val();

		let urlApi = '';
		let dataApi = {};

		if (selectedCate === 'all') {
			urlApi = 'home/LttLoadSp'; // API lấy tất cả
		} else {
			urlApi = 'home/LttLoadByCate'; // API lọc theo loại
			dataApi = { id: selectedCate }; // Truyền ID loại
		}

		$.ajax({
			url: urlApi,
			data: dataApi,
            dataType: 'json',
			success: function(res){
                renderProduct(res);
			}
		})
	})
</script>
```

## load theo loai nhung ko filter giong c3

```c#
 public JsonResult LttLoadTheoLoai()
 {
     var cate = _db.Categories.ToList();
     return Json(cate);
 }

 public JsonResult LttLoadSanPham()
 {
     var products = _db.Products.Where(p => p.Available && p.UnitPrice <= 1000).ToList();
     return Json(products);
 }

 public JsonResult LttLoadCate(int id)
 {
     var products = _db.Products.Where(p => p.CategoryId == id).ToList();
     return Json(products);
 }

```

```html
	<script>
		$(document).ready(function(){
			$('.categories ul').html('');
			let item = ``;
			$.ajax({
				url: 'home/LttLoadTheoLoai',
				dataType: 'json',
				success: function(res){
					console.log(res);
					res.forEach(row => {
						item += `<li><a href="#" data-id="${row.id}"><i class="fa fa-arrow-right" aria-hidden="true"></i>${row.name}</a></li>`
					});
					$('.categories ul').html(item);
				}
			});
		});
	</script>

	<script>

		function renderProducts(data) {
			var container = $('.agile_top_brands_grids');
			container.html(''); 


			let itemBox = ``;
			data.forEach(item => {
				itemBox +=
					`<div class="col-md-4 top_brand_left">
						<div class="hover14 column">
							<div class="agile_top_brand_left_grid">
								<div class="agile_top_brand_left_grid_pos">
									<img src="images/offer.png" alt=" " class="img-responsive">
								</div>
								<div class="agile_top_brand_left_grid1">
									<figure>
										<div class="snipcart-item block">
											<div class="snipcart-thumb">
												<a href="single.html"><img title=" " alt=" " src="images/${item.image}"></a>
												<p>${item.name}</p>
												<h4>${item.unitPrice} <span>$55.00</span></h4>
											</div>
											<div class="snipcart-details top_brand_home_details">
												<form action="#" method="post">
													<fieldset>
														<input type="hidden" name="cmd" value="_cart">
														<input type="hidden" name="add" value="1">
														<input type="hidden" name="business" value=" ">
														<input type="hidden" name="item_name" value="Fortune Sunflower Oil">
														<input type="hidden" name="amount" value="35.99">
														<input type="hidden" name="discount_amount" value="1.00">
														<input type="hidden" name="currency_code" value="USD">
														<input type="hidden" name="return" value=" ">
														<input type="hidden" name="cancel_return" value=" ">
														<input type="submit" name="submit" value="Add to cart" class="button">
													</fieldset>
												</form>
											</div>
										</div>
									</figure>
								</div>
							</div>
						</div>
					</div>`
				});
				container.html(itemBox);
		}

		$(document).ready(function(){
			sanphams = [];
			$('.agile_top_brands_grids').html('');
			let itemBox = ``;
			$.ajax({
				url: 'home/LttLoadSanPham',
                dataType: 'json',
				success: function(res){
					   renderProducts(res);
				}
			});
		});

	</script>

	<script>
		$(document).on('click', '.categories ul li a', function(e){
			e.preventDefault();
			let cateId = $(this).attr('data-id');

			$.ajax({
				url: 'home/LttLoadCate',
				data: { id: cateId },
				dataType: 'json',
				success: function(res){
					console.log(res);
					renderProducts(res);
				}
            });

		});
	</script>
```


# KO AJAX
- ghép index vào layout 
- tách các partial
	```html
	 <!--Header Section-->
	 <partial name="_HeaderPartial" />
	 <!--Main Body-->
	 @RenderBody()
	 <!--Footer Section-->
	 <partial name="_FooterPartial" />
	```

- ghép các css, js, images vào wwwroot
- tải 4 entity
- liên kết db
	```
	Scaffold-DbContext "Server=LAPTOP-VNJ8Q8JU\THOU;Database=QLHangHoa;User Id=sa;Password=thou;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
	```

	```
	Scaffold-DbContext "Server=.\THOU; Database=QLHangHoa; Trusted_Connection=True; TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models
	```

- thêm vao `appsetting.json`
	```
	"ConnectionStrings": {
	  "DefaultConnection": "Server=.\THOU; Database=QLHangHoa; Trusted_Connection=True; TrustServerCertificate=True;"
	}
	```


- them vao `program.cs`
	```cs
	// Add services to the container.
	builder.Services.AddControllersWithViews();
	
	builder.Services.AddDbContext<QlhangHoaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
	
	var app = builder.Build();
	```



- them vao home/index
	```cs
	@{
	    ViewData["Title"] = "Home Page";
	    Layout = "~/Views/Shared/LeThiThao_Layout.cshtml";
	}
	```
## Câu 1: Tạo Project và Cấu hình Layout (2 điểm)

1. **Tạo Project:**
    - Mở Visual Studio, chọn **Create a new project** -> **ASP.NET Core Web App (Model-View-Controller)**.
    - Đặt tên project: `HoTen_MaSV` (Ví dụ: `NguyenVanA_123456`).
2. **Nhúng tài nguyên (css, js, images):**
    - Copy toàn bộ thư mục `css`, `js`, `images` từ đề bài vào thư mục `wwwroot` của project.
3. **Cắt Layout (`_Layout.cshtml`):**
    - Mở file `index.html` đề bài cung cấp, copy toàn bộ nội dung.
    - Dán vào file `Views/Shared/_Layout.cshtml`.
    - **Tách Partial View:** Tạo các file trong thư mục `Views/Shared`:
        - `_Header.cshtml`: Chứa phần đầu trang (Menu, Logo).
        - `_Footer.cshtml`: Chứa phần chân trang.
    - Trong `_Layout.cshtml`, gọi lại bằng:
        ```html
        <partial name="_Header" />
        <div class="container">
            <main role="main" class="pb-3">
                @RenderBody()  </main>
        </div>
        <partial name="_Footer" />
        ```
    - **Lưu ý:** Sửa đường dẫn css/js/image trong code HTML cho đúng với `~/css/...`, `~/images/...`.

## Câu 2: Hiển thị Menu và Database First (2 điểm)
- **Scaffold Database (Reverse Engineer):**
    - Mở **Package Manager Console**.
    - Gõ lệnh (nhớ thay đổi `ServerName` và `DatabaseName`):
        ```PowerShell
        Scaffold-DbContext "Server=TEN_SERVER;Database=TEN_DB;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
        ```
        
- **Hiển thị Menu LoaiHang:**
    - Dùng **ViewComponent**.
    - Tạo class `ViewComponents/LoaiHangMenuViewComponent.cs`:
        ```c#
        public class LoaiHangMenuViewComponent : ViewComponent {
            private readonly TenDbContext _context; // Inject DbContext vào
            public LoaiHangMenuViewComponent(TenDbContext context) { _context = context; }
        
            public IViewComponentResult Invoke() {
                var loaihang = _context.LoaiHangs.ToList();
                return View(loaihang);
            }
        }
        ```
        
    - Tạo View cho Component: `Views/Shared/Components/LoaiHangMenu/Default.cshtml`.
        ```html
        @model IEnumerable<LeThiThao_231230910.Models.LoaiHang>
			<ul>
			    <li class="active"><a href="/">Le Thi Thao</a></li>
			
			    @foreach (var item in Model)
			    {
			        <li>
			            <a href="#" class="ajax-link" data-id="@item.MaLoai">
			                @item.TenLoai
			            </a>
			        </li>
			    }
			
			    <div class="clear"></div>
			</ul>
        ```
    - Inject vào layout  `@await Component.InvokeAsync("LoaiHangMenu")`
	    ```html
	    <div class="header">
			<div class="header_top">
				<div class="logo">
					<a href="/"><img src="~/images/logo.png" alt="" /></a>
				</div>
				<div class="cart">
					<p>
						Welcome to our Online Store! <span>Cart:</span><div id="dd" class="wrapper-dropdown-2">
							0 item(s) - $0.00
							<ul class="dropdown">
								<li>you have no items in your Shopping cart</li>
							</ul>
						</div>
					</p>
				</div>
				<div class="clear"></div>
			</div>
			<div class="header_bottom">
				<div class="menu">
					@await Component.InvokeAsync("LoaiHangMenu")
				</div>
				<div class="search_box">
					<form>
						<input type="text" value="Search" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Search';}">
						<input type="button" value="">
					</form>
				</div>
				<div class="clear"></div>
			</div>
		</div>
	    ```

## Câu 3: Hiển thị Danh sách Hàng Hóa (1 điểm)
- **Controller:** Trong `HomeController`, inject DbContext.
	```
	 QlhangHoaContext db = new QlhangHoaContext();
	```
- Action Index:
	```cs
	public IActionResult Index()
	{
	    var hanghoa = db.HangHoas.Where(h => h.Gia >= 100).ToList();
	    return View(hanghoa);
	
	}
	```

- Tạo Partial View `_ProductList.cshtml`
	- **Vị trí:** `Views/Shared/_ProductList.cshtml`
	```html
	@model IEnumerable<LeThiThao_231230910.Models.HangHoa>
	@foreach(var item in Model)
	{
		<div class="grid_1_of_4 images_1_of_4">
			@* 1. Hiển thị ảnh: Dùng ~/images/ và tên file từ CSDL *@
			<a href="preview.html"><img src="~/images/@item.Anh" alt="@item.TenHang" /></a>
			@* 2. Hiển thị Tên hàng *@
			<h2>@item.TenHang</h2>
			<div class="price-details">
				<div class="price-number">
					@* 3. Hiển thị Giá *@
					<p><span class="rupees">@item.Gia</span></p>
				</div>
				<div class="add-cart">
					<h4><a href="preview.html">Add to Cart</a></h4>
				</div>
				<div class="clear"></div>
			</div>
		</div>
	}
	```

- Sửa file `Index.cshtml`
	```html
	<div class="content">
	<!-- Begin New Product -->
		<div class="content_top">
			<div class="heading">
				<h3>Lê Thị Thảo</h3>
			</div>
			<div class="see">
				<p><a href="#">See all Products</a></p>
			</div>
			<div class="clear"></div>
		</div>
		@* QUAN TRỌNG: - Thêm id="content-product" để lát nữa AJAX (Câu 4) biết chỗ nào mà đổ dữ liệu vào. - Gọi Partial View _ProductList để hiển thị danh sách sản phẩm. *@
		<div class="section group" id="content-product">
	        <partial name="LeThiThao_ProductList" model="Model" />
		</div>
		<!-- End New Product -->
	</div>
	```


## Câu 4: Lọc sản phẩm bằng AJAX (2 điểm)
- Viết Action trong Controller:
	```cs
	public IActionResult GetProductsByLoai(int maLoai)
	{
	    var products = db.HangHoas.Where(h => h.MaLoai == maLoai && h.Gia >= 100).ToList();
	    return PartialView("LeThiThao_ProductList", products);
	}
	```
- Viết JavaScript (AJAX)
	- Gắn sự kiện `click` vào các thẻ `<a>` của Menu LoaiHang (ở Câu 2).
	- trong home/index thêm vào cuối
		```html
		
		@section Scripts {
		    <script>
		        $(document).ready(function () {
		            $(".ajax-link").click(function (e) {
		                e.preventDefault();
		                var id = $(this).data("id");
		                $.ajax({
		                    url: "/Home/GetProductsByLoai", 
		                    data: { maLoai: id },
		                    success: function (response) {
		                        $("#content-product").html(response);
		                    }
		                });
		            });
		        });
		    </script>
		}

		```

## Câu 5: Thêm mới và Validate (3 điểm)

Cấu hình Validation trong Model
**File:** `Models/HangHoa.cs`
```c#
    [Range(100, 5000, ErrorMessage = "Giá phải nằm trong khoảng từ 100 đến 5000")]
    public decimal? Gia { get; set; }

    [RegularExpression(@"^.*\.(jpg|png|gif|tiff)$", ErrorMessage = "Đuôi file phải là .jpg, .png, .gif hoặc .tiff")]
    public string? Anh { get; set; }
```

Thêm mới
Viết Action trong Controller
**File:** `Controllers/HomeController.cs`
```c#
[HttpGet]
[Route("create")]
public IActionResult Create()
{
    ViewBag.MaLoai = new SelectList(db.LoaiHangs, "MaLoai", "TenLoai");
    return View();
}

[HttpPost]
[Route("create")]
public IActionResult Create(HangHoa hangHoa)
{
    //Kiểm tra xem dữ liệu có thỏa mãn các điều kiện Validation ở Phần 1 không
    if (ModelState.IsValid)
    {
        db.HangHoas.Add(hangHoa);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    // Nếu lỗi (ví dụ nhập giá 50), load lại danh sách loại hàng để hiện lại form
    ViewBag.MaLoai = new SelectList(db.LoaiHangs, "MaLoai", "TenLoai", hangHoa.MaLoai);
    return View(hangHoa);
}
```

Tạo View Create
Chuột phải vào thư mục `Views/Home` -> **Add** -> **View** -> **Razor View - Empty** -> Đặt tên `Create.cshtml`.


# AJax

# câu 2
home Controller
```c#
 public JsonResult LttLoadLoaiHang()
 {
     var loaihang = _context.LoaiHangs.ToList();
     return Json(loaihang);
 }
```

```c#

```


ltt_layout
```html
<script>
	$(document).ready(function(){
		console.log("running...");
		$('.menu ul').html('');
		item = '<li class="active"><a href="/" data-id="0">Lê Thị Thảo</a></li>';
		$.ajax({
			url: 'home/lttloadloaihang',
			dataType: 'json',
			success: function(res){
				console.log(res);
				res.forEach(row => {
					item += `<li><a href="#" data-id="${row.maLoai}">${row.tenLoai}</a></li>`
				});
				item += '</ul>';
				$('.menu ul').html(item);
			}
		});
	});
</script>
```

```html
<script>
	$(document).ready(function(){
		console.log("running...");
		$('.menu ul').html('');
		item = '<li class="active"><a href="/" data-id="0">Lê Thị Thảo</a></li>';
		$.ajax({
			url: 'home/lttloadloaihang',
			dataType: 'json',
			success: function(res){
				console.log(res);
				res.forEach(row => {
					item += `<li><a href="#" data-id="${row.maLoai}">${row.tenLoai}</a></li>`
				});
				item += '</ul>';
				$('.menu ul').html(item);
			}
		});
	});
</script>
```

## câu 3
home Controller
```c#
	public JsonResult LttHangHoaByLoai()
	{
		var hanghoa = _context.HangHoas.Where(x => x.Gia >= 100).ToList();
		return Json(hanghoa);
	}
```

ltt_layout
```html
<script>
	$(document).on('click', '.menu ul li a', function(e){
		e.preventDefault();
		let maLoai = $(this).attr('data-id');
		let data = hanghoas.filter(x => x.maLoai == maLoai);
		if(maLoai == "0"){
			data = hanghoas;
		}
		$('.content .section').html('');
		let itemBox = ``;
		data.forEach(item => {
			itemBox += `
			<div class="grid_1_of_4 images_1_of_4">
				<a href="preview.html"><img src="images/${item.anh}" alt="" /></a>
				<h2>${item.tenHang}</h2>
				<div class="price-details">
					<div class="price-number">
						<p><span class="rupees">${item.gia}</span></p>
					</div>
					<div class="add-cart">
						<h4><a href="preview.html">Add to Cart</a></h4>
					</div>
					<div class="clear"></div>
				</div>
			</div>
			`
		})
		$('.content .section').html(itemBox);

	});
</script>
```

## câu 4
```html
<script>
	$(document).on('click', '.menu ul li a', function(e){
		e.preventDefault();
		let maLoai = $(this).attr('data-id');
		let data = hanghoas.filter(x => x.maLoai == maLoai);
		if(maLoai == "0"){
			data = hanghoas;
		}
		$('.content .section').html('');
		let itemBox = ``;
		data.forEach(item => {
			itemBox += `
			<div class="grid_1_of_4 images_1_of_4">
				<a href="preview.html"><img src="images/${item.anh}" alt="" /></a>
				<h2>${item.tenHang}</h2>
				<div class="price-details">
					<div class="price-number">
						<p><span class="rupees">${item.gia}</span></p>
					</div>
					<div class="add-cart">
						<h4><a href="preview.html">Add to Cart</a></h4>
					</div>
					<div class="clear"></div>
				</div>
			</div>
			`
		})
		$('.content .section').html(itemBox);

	});
</script>
```


## search

home controller
```c#
public JsonResult LttSearch(string keyword)
{
    if (string.IsNullOrEmpty(keyword))
    {
        var all = _context.HangHoas.ToList();
        return Json(all);
    }

    var data = _context.HangHoas
                .Where(x => x.TenHang.Contains(keyword))
                .ToList();

    return Json(data);
}
```

header them id
```html
<div class="search_box">
	<form>
		<input id="txtSearch" type="text" value="Search" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Search';}">
		<input id="btnSearch" type="button" value="">
	</form>
</div>
```

lttlayout
```html
<script>
		$(document).ready(function () {

		// Search khi bấm nút
		$('#btnSearch').click(function () {
			SearchByName();
		});

		// Search realtime khi gõ
		$('#txtSearch').keyup(function () {
			SearchByName();
		});

	});

	function SearchByName() {
		let keyword = $('#txtSearch').val();

		$.ajax({
			url: '/Home/LttSearch',
			data: { keyword: keyword },
			dataType: 'json',
			success: function (res) {
				let html = '';

				res.forEach(item => {
					html += `
						<div class="grid_1_of_4 images_1_of_4">
							<a href="preview.html"><img src="images/${item.anh}" alt="" /></a>
							<h2>${item.tenHang}</h2>
							<div class="price-details">
								<div class="price-number">
									<p><span class="rupees">${item.gia}</span></p>
								</div>
								<div class="add-cart">
									<h4><a href="preview.html">Add to Cart</a></h4>
								</div>
								<div class="clear"></div>
							</div>
						</div>
					`;
				});

				$('.content .section').html(html);
			}
		});
	}
</script>
```


## Lấy 5 sp giá cao nhất

## lọc theo gì đó??

## regular expression
- tên
- sđt
- email

## phân trang

-----
## References
1.
