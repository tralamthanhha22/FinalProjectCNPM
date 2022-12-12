using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalWeb.Models;
using FinalWeb.Others;


namespace FinalWeb.Controllers
{
    public class ORDERsController : Controller
    {
        static int total;
        static String paymentstatus="chưa trả tiền";
        private DevConn db = new DevConn();

        // GET: ORDERs
        public ActionResult Index()
        {
            ViewBag.Order = db.ORDER.ToList();
            //return View(db.ORDER.Where(order => order.AGENTID.Equals(Session["AGENTID"])).ToList());
            return View();
        }

        // GET: ORDERs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Id = id;
            ViewBag.OrderDetail = db.ORDER_DETAIL.ToList();
            ViewBag.Product=db.PRODUCT.ToList();
            ORDER oRDER = db.ORDER.Find(id);
            if(oRDER.PAYMENTMETHOD=="Chuyển khoản")
            {
                oRDER.PAYMENTSTATUS = paymentstatus;
                System.Diagnostics.Debug.WriteLine("\n payment status 1: " + oRDER.PAYMENTSTATUS + "\n");
            }
            else
            {
                oRDER.PAYMENTSTATUS = "chưa trả tiền";
            }
            total = Convert.ToInt32(oRDER.Total)*100;
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            var delivery=db.DELIVERY.Find(oRDER.DELIVERYNOTE_ID);
            ViewBag.delivery=delivery.DELIVERYFEE;
            db.SaveChanges();
            return View(oRDER);
        }
        // GET: ORDERs/MarkReceive/[OrderID]
        public ActionResult MarkReceive(string OrderID)
        {
            var OrderData=db.ORDER.Find(OrderID);
            OrderData.ORDERSTATUS = "Đã nhận được hàng";

            foreach(var OrderDetailData in db.ORDER_DETAIL.ToList())
            {
                if(OrderDetailData.ORDERID.Equals(OrderID))
                {
                    foreach(var ProductData in db.PRODUCT.ToList())
                    {
                        if (ProductData.PRODUCTID.Equals(OrderDetailData.PRODUCTID))
                        {
                            ProductData.HASSOLD += OrderDetailData.BUYQUANTITY;
                            ProductData.PROQUANTITY -= OrderDetailData.BUYQUANTITY;
                        }
                    }  
                }

                //var ProductData = db.PRODUCT.Find(OrderDetailData.PRODUCTID);
                //ProductData.HASSOLD += OrderDetailData.BUYQUANTITY;
                //ProductData.PROQUANTITY -= OrderDetailData.BUYQUANTITY;
            }    
            db.SaveChanges();
            ViewBag.Mess = "đánh dấu nhận hàng thành công";
            return View();
        }

        // GET: ORDERs/Create
        public ActionResult Create()
        {
            if (Session["AGENTID"]==null)
            {
                return RedirectToAction("Login","Home");
            }
            ViewBag.Delivery = db.DELIVERY.ToList();
            ViewBag.OrderDetails=db.ORDER_DETAIL.ToList();
            ViewBag.Products=db.PRODUCT.ToList();
            ViewBag.Count = "O000" + db.ORDER.Count().ToString();
            ViewBag.AGENTID = Session["AGENTID"];
            ViewBag.OrderDetail="OD00"+db.ORDER_DETAIL.Count().ToString();
            Session["deliveryFee"] = 0;
            return View();
        }

        // POST: ORDERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="ODETAIL_ID,ODERID,PRODUCTID,BUYQUANTITY")]ORDER_DETAIL oRDER_detail,
            [Bind(Include = "ORDERID,AGENTID,DELIVERYNOTE_ID,ORDERDATE,ORDERSTATUS,PAYMENTSTATUS,PAYMENTMETHOD")] ORDER oRDER)
        {
            if (ModelState.IsValid)
            {
                List<Cart> li2 = Session["cart"] as List<Cart>;
                List<ORDER_DETAIL>oRDER_DETAILs= new List<ORDER_DETAIL>();
                
                var len = db.ORDER_DETAIL.Count();
                int deliveryFee = 0;
                var delivery = db.DELIVERY.Where(deliver => deliver.DELIVERYNOTE_ID.Equals(oRDER.DELIVERYNOTE_ID));
                foreach (var d in delivery)
                {
                    deliveryFee = Convert.ToInt32(d.DELIVERYFEE);
                }
                foreach (var p in li2)
                {
                    
                    oRDER.Total = deliveryFee+Convert.ToInt32(Session["total"]);
                    oRDER_detail.ODETAIL_ID = "OD00" + len;
                    oRDER_detail.ORDERID = "O000" + db.ORDER.Count().ToString();
                    oRDER_detail.PRODUCTID = p.ProID;
                    oRDER_detail.BUYQUANTITY = p.qty;
                    Session["deliveryFee"] = deliveryFee;
                    System.Diagnostics.Debug.WriteLine(total);
                    oRDER_DETAILs.Add(new ORDER_DETAIL
                    {
                        ODETAIL_ID= "OD00" + len,
                        PRODUCTID = p.ProID,
                        BUYQUANTITY = p.qty,
                        ORDERID= "O000" + db.ORDER.Count().ToString(),
                    });
                    db.ORDER_DETAIL.AddRange(oRDER_DETAILs);
                    
                    len++;
                    continue;
                }
                //oRDER.PAYMENTSTATUS = "chưa trả tiền";
                db.ORDER.Add(oRDER);
                db.SaveChanges();
                li2.Clear();
                Session["item_count"] = 0;
                Session["total"] = 0;
                
                return RedirectToAction("Index");
            }

            return View(oRDER);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Payment()
        {
            string url = ConfigurationManager.AppSettings["Url"];
            string returnUrl = ConfigurationManager.AppSettings["ReturnUrl"];
            string tmnCode = ConfigurationManager.AppSettings["TmnCode"];
            string hashSecret = ConfigurationManager.AppSettings["HashSecret"];

            PayLib pay = new PayLib();
            pay.AddRequestData("vnp_Version", "2.1.0"); //Phiên bản api mà merchant kết nối. Phiên bản hiện tại là 2.1.0
            pay.AddRequestData("vnp_Command", "pay"); //Mã API sử dụng, mã cho giao dịch thanh toán là 'pay'
            pay.AddRequestData("vnp_TmnCode", tmnCode); //Mã website của merchant trên hệ thống của VNPAY (khi đăng ký tài khoản sẽ có trong mail VNPAY gửi về)
            pay.AddRequestData("vnp_Amount", Convert.ToString(total)); //số tiền cần thanh toán, công thức: số tiền * 100 - ví dụ 10.000 (mười nghìn đồng) --> 1 000 000
            pay.AddRequestData("vnp_BankCode", ""); //Mã Ngân hàng thanh toán (tham khảo: https://sandbox.vnpayment.vn/apis/danh-sach-ngan-hang/), có thể để trống, người dùng có thể chọn trên cổng thanh toán VNPAY
            pay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss")); //ngày thanh toán theo định dạng yyyyMMddHHmmss
            pay.AddRequestData("vnp_CurrCode", "VND"); //Đơn vị tiền tệ sử dụng thanh toán. Hiện tại chỉ hỗ trợ VND
            pay.AddRequestData("vnp_IpAddr", Util.GetIpAddress()); //Địa chỉ IP của khách hàng thực hiện giao dịch
            pay.AddRequestData("vnp_Locale", "vn"); //Ngôn ngữ giao diện hiển thị - Tiếng Việt (vn), Tiếng Anh (en)
            pay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang"); //Thông tin mô tả nội dung thanh toán
            pay.AddRequestData("vnp_OrderType", "other"); //topup: Nạp tiền điện thoại - billpayment: Thanh toán hóa đơn - fashion: Thời trang - other: Thanh toán trực tuyến
            pay.AddRequestData("vnp_ReturnUrl", returnUrl); //URL thông báo kết quả giao dịch khi Khách hàng kết thúc thanh toán
            pay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString()); //mã hóa đơn

            string paymentUrl = pay.CreateRequestUrl(url, hashSecret);

            return Redirect(paymentUrl);
        }

        public ActionResult PaymentConfirm()
        {
            if (Request.QueryString.Count > 0)
            {
                string hashSecret = ConfigurationManager.AppSettings["HashSecret"]; //Chuỗi bí mật
                var vnpayData = Request.QueryString;
                PayLib pay = new PayLib();

                //lấy toàn bộ dữ liệu được trả về
                foreach (string s in vnpayData)
                {
                    if (!string.IsNullOrEmpty(s) && s.StartsWith("vnp_"))
                    {
                        pay.AddResponseData(s, vnpayData[s]);
                    }
                }

                long orderId = Convert.ToInt64(pay.GetResponseData("vnp_TxnRef")); //mã hóa đơn
                long vnpayTranId = Convert.ToInt64(pay.GetResponseData("vnp_TransactionNo")); //mã giao dịch tại hệ thống VNPAY
                string vnp_ResponseCode = pay.GetResponseData("vnp_ResponseCode"); //response code: 00 - thành công, khác 00 - xem thêm https://sandbox.vnpayment.vn/apis/docs/bang-ma-loi/
                string vnp_SecureHash = Request.QueryString["vnp_SecureHash"]; //hash của dữ liệu trả về

                bool checkSignature = pay.ValidateSignature(vnp_SecureHash, hashSecret); //check chữ ký đúng hay không?

                if (checkSignature)
                {
                    if (vnp_ResponseCode == "00")
                    {
                        //Thanh toán thành công
                        ViewBag.Message = "Thanh toán thành công hóa đơn VNPAY" + orderId + " | Mã giao dịch: " + vnpayTranId;
                        paymentstatus = "Đã thanh toán thành công";
                        System.Diagnostics.Debug.WriteLine("\n payment status : " + paymentstatus + "\n");
                    }
                    else
                    {
                        //Thanh toán không thành công. Mã lỗi: vnp_ResponseCode
                        ViewBag.Message = "Có lỗi xảy ra trong quá trình xử lý hóa đơn " + orderId + " | Mã giao dịch: " + vnpayTranId + " | Mã lỗi: " + vnp_ResponseCode;
                    }
                }
                else
                {
                    ViewBag.Message = "Có lỗi xảy ra trong quá trình xử lý";
                }
            }

            return View();
        }
    }
}
