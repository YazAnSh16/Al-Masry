<%@ Page Title="حول المعهد" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="AL_Masry.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body, .about-container {
            direction: ltr;
            text-align: right;
        }

        .about-container {
            max-width: 900px;
            margin: 40px auto;
            padding: 20px;
            background: #ffffff;
            border-radius: 15px;
            box-shadow: 0 4px 15px rgba(0,0,0,0.1);
        }

        .about-container h1, 
        .about-container h2 {
            text-align: center; /* نخلي العناوين بالوسط */
        }

        .about-container h1 {
            color: #2c3e50;
            font-size: 2rem;
            margin-bottom: 10px;
        }

        .about-container h2 {
            color: #16a085;
            font-size: 1.4rem;
            margin-top: 25px;
            margin-bottom: 10px;
        }

        .about-logo {
            width: 200px;
            height: 200px;
            border-radius: 50%;
            margin: 15px auto;
            display: block;
            object-fit: cover;
            border: 3px solid #16a085;
        }

        .info-list {
            list-style: none;
            padding: 0;
            margin-top: 15px;
        }

        .info-list li {
            margin: 8px 0;
            font-size: 1rem;
            color: #444;
        }

        .highlight {
            color: #e67e22;
            font-weight: bold;
        }

        .reasons {
            direction : rtl;
            text-align: right;
            margin: 20px auto;
            max-width: 750px;
            padding-right: 20px;
        }

        .reasons li {
            margin-bottom: 8px;
            color: #333;
        }

        .map-container {
            margin: 30px auto;
            max-width: 100%;
        }

        .map-container iframe {
            width: 100%;
            height: 350px;
            border: none;
            border-radius: 10px;
        }

        .developer-box {
            direction :rtl;
            margin-top: 30px;
            padding: 15px;
            background: #f9f9f9;
            border-right: 5px solid #16a085; /* غيرنا من left ل right */
        }

        .developer-box h3 {
            margin-bottom: 10px;
            color: #2c3e50;
        }

        .developer-box p {
            margin: 5px 0;
            color: #555;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="about-container">
        <h1>معهد المصري للعلوم واللغات</h1>
        <p style="text-align:center"><em>طريقك نحو التميز</em></p>

        <!-- صورة شعار/طالب -->
        <img src="Img/WhatsApp_Image_2025-08-07_at_20.23.49-removebg-preview.png" alt="شعار المعهد" class="about-logo" />

        <h2>لماذا معهد المصري هو اختيارك الأفضل؟</h2>
        <ul class="reasons">
            <li>✔️ لأننا نؤمن بأن لكل طالب طريقًا خاصًا للنجاح.</li>
            <li>✔️ لأن نجاحك هو أولويتنا.</li>
            <li>✔️ لأن جودة التعليم هي وعدنا لا مجرد شعارات.</li>
            <li>✔️ نتميز بكادر تدريسي متمرس وملتزم بخبرة واسعة.</li>
        </ul>

        <h2>النظام التعليمي</h2>
        <ul class="reasons">
            <li>📘 فصل الباحات للذكور والإناث بما يضمن الخصوصية.</li>
            <li>📘 اختبارات دورية لقياس مستوى الطلبة.</li>
            <li>📘 تواصل مستمر مع أولياء الأمور.</li>
        </ul>

        <h2>معلومات التواصل</h2>
        <ul class="info-list">
            <li><span class="highlight">📍 العنوان:</span> شارع الزيتون، جانب مدرسة أحمد الحفيري</li>
            <li><span class="highlight">☎️ الهاتف:</span> 0117754310</li>
            <li><span class="highlight">📞 الجوال:</span> +963934273283</li>
            <%--<li><span class="highlight">🌐 الموقع:</span> www.almasri-institute.com</li>--%>
            <div class="contact-icons" style="text-align:center; margin-top:20px;">
    <!-- Facebook -->
    <a href="https://www.facebook.com/61562271076297" target="_blank" style="margin:0 10px; text-decoration:none;">
        <img src="https://cdn-icons-png.flaticon.com/512/733/733547.png" 
             alt="Facebook" width="40" style="vertical-align:middle;">
    </a>

    <!-- WhatsApp -->
    <a href="https://wa.me/+963934273283" target="_blank" style="margin:0 10px; text-decoration:none;">
        <img src="https://cdn-icons-png.flaticon.com/512/733/733585.png" 
             alt="WhatsApp" width="40" style="vertical-align:middle;">
    </a>
</div>

        </ul>

        <!-- خريطة جوجل -->
        <div class="map-container">
            <h2 style="text-align:center">موقعنا على الخريطة</h2>
            <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d986.4816390122888!2d36.602204669352844!3d33.73182946280472!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2sus!4v1755668210090!5m2!1sen!2sus" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
        </div>
        
        <!-- مطور الموقع -->
        <div class="developer-box">
            <h3>تواصل مع مطوّر الموقع</h3>
            <p><span class="highlight">👨‍💻 الاسم:</span> يزن شحادة</p>
            <p><span class="highlight">📧 البريد:</span> yazan166shh@gmail.com</p>
            <p><span class="highlight"  >☎️ الهاتف:</span> +963938336147</p>
            <p><span class="highlight"  >🌐 الموقع:</span> <a href="https://yazan-sh.great-site.net/" style="color:#16a085; direction:ltr"> yazan-sh.com  </a> </p>
            
            <div class="contact-icons" style="text-align:center; margin-top:20px;">
             <!-- Facebook -->
                <a href="https://www.facebook.com/yazan.sh.943257" target="_blank" style="margin:0 10px; text-decoration:none;">
                <img src="https://cdn-icons-png.flaticon.com/512/733/733547.png" 
             alt="Facebook" width="40" style="vertical-align:middle;">
             </a>

                 <!-- WhatsApp -->
            <a href="https://wa.me/+963938336147" target="_blank" style="margin:0 10px; text-decoration:none;">
        <img src="https://cdn-icons-png.flaticon.com/512/733/733585.png" 
             alt="WhatsApp" width="40" style="vertical-align:middle;">
                </a>
                </div>


        </div>
    </div>
</asp:Content>
