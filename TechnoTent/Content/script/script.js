$(document).ready(function () {
	banCopyImg();

	$(".header-nav")
	.mouseover(function(){
        if(window.innerWidth >= 992){
            $(".nav__list").addClass("block");
        }
	})
	.mouseleave(function() {
        if(window.innerWidth >= 992){
            if (!$("section").is(".slider"))
            {
                $(".nav__list").removeClass("block");       
            }
        }
	}).click(function(e){       
        if(window.innerWidth < 992){
            $(".nav__list").toggleClass("block");
        } 
    });
    if($(".header-nav").length == 1){
        $(document).click(function (e){
            if(window.innerWidth < 992){
                if(!$(".header-nav").is(e.target) && !$(".header-nav *").is(e.target)){
                    $(".nav__list").removeClass("block");       
                }
            }
        });
    }

    //
    $(".header-menu__toggle").click(function(){
        $(".header-menu__list").toggleClass("menu-list__height");
    });
    if($(".header-menu__list").length == 1){
        $(document).click(function (e){
            if(!$(".header-menu__toggle").is(e.target) && !$(".header-menu__toggle *").is(e.target) && !$(".header-menu__list").is(e.target) && !$(".header-menu__list *").is(e.target)){
                $(".header-menu__list").removeClass("menu-list__height");       
            }
        });
    }
    //

	$(".auth-tabs__item").click(function(e){            
        if(!($(this).hasClass("active")))
        {
            $(this).parent().find(".auth-tabs__item.active").removeClass("active");
            let authForm = $(this).attr("data-form");                
            $(".auth-tabs__wrapper").removeClass("auth-tabs--active");
            authForm = document.getElementsByClassName(authForm)
            $(authForm).addClass("auth-tabs--active");
            $(this).addClass("active");
        }
    });

	$(".form-input__icon-password").click(function(){
        let typeInput = $(this).siblings().eq(0);
        if(typeInput.attr("type") == "password"){
            typeInput.attr("type", "text");
            $(this).removeClass("fa-lock");
            $(this).addClass("fa-lock-open");
        }
        else{
            typeInput.attr("type", "password");
            $(this).removeClass("fa-lock-open");
            $(this).addClass("fa-lock");               
        }            
    });

	function banCopyImg(){
		var img = $("img");
		for(var i in img)
		{
		    img[i].oncontextmenu = function()
		    {
		        return false;
		    }
		}
	}

	//form validation

    let errorTitle = false;    
    let errorMessage = false;   
    let errorName = false;
    let errorEmail = false;
    let errorPassword = false;
    let errorNewPassword = false;
    let errorNewPasswordAgain = false;
    let errorTel = false;
    let errorCity = false;
    let errorAddress = false;
    let similarityPassword = false;

    let inputTitle = $(".form-input__title");    
    let inputMessage = $(".form-textarea__message");
    let inputName = $(".form-input__name");
    let inputLogin = $(".form-input__login");
    let inputEmail = $(".form-input__email");
    let inputPassword = $(".form-input__password");
    let inputTel = $(".form-input__tel");
    let inputCity = $(".form-input__city");
    let inputAddress = $(".form-input__address");
    let langth = 1;


    $('.form-input__password').on("focusout", function() {
        inputPassword=$(this);
        langth = 6;
        errorPassword = checkInput(inputPassword, langth, errorPassword);
    });
    $('.form-input__name').on("focusout", function() {
        inputName=$(this);
        langth = 3;
        errorName = checkInput(inputName, langth, errorName);
    });
    $('.form-input__email').on("focusout", function() {        
        inputEmail = $(this);
        errorEmail = checkEmail(inputEmail, errorEmail);       
    });
    $('.form-input__tel').on("focusout", function() {
        inputTel=$(this);       
        errorTel = checkTel(inputTel, errorTel);        
    });
    $(".form-textarea__message").on("focusout", function() {
        inputMessage = $(this);
        langth = 5;
        errorMessage = checkInput(inputMessage, langth, errorMessage);     
    });

    //sign-in form
    $(".sign-in .auth-form").submit(function(){
        inputEmail = $(".sign-in .form-input__login");
        inputPassword = $(".sign-in .form-input__password");
        errorEmail = checkEmail(inputEmail, errorEmail);
        langth = 1;
        errorPassword = checkInput(inputPassword, langth, errorPassword);        
        if(errorEmail == false && errorPassword == false){            
            return true;
        } else {
            return false;
        }
    });
    //

    //sign-up form
    $(".sign-up .auth-form").submit(function(){
        inputName = $(".sign-up .form-input__name");
        inputLogin = $(".sign-up .form-input__login");
        inputPassword = $(".sign-up .form-input__password");             
        
        langth = 3;
        errorName = checkInput(inputName, langth, errorName);
        errorEmail = checkEmail(inputLogin, errorEmail);
        langth = 6;
        errorPassword = checkInput(inputPassword, langth, errorPassword);
        
        if ($(".sign-up .form-input__password").eq(0).val().length >= 6) {
            comparePassword();                            
        }
        else {
            similarityPassword = true;
        }                      
        if(errorName==false && errorEmail == false && errorPassword == false && similarityPassword == false) {
            return true;               
        } 
        else {
            return false;                 
        }    
    });
    function comparePassword(){
        let passwordFirst = $(".sign-up .form-input__password").eq(0).val(); 
        let passwordSecond = $(".sign-up .form-input__password").eq(1).val(); 
        if(passwordFirst == passwordSecond) 
        {      
            similarityPassword = false;                 
            $(".sign-up .form-input__password").eq(1).siblings().eq(2).fadeOut(1000);     
        } 
        else if ($(".sign-up .form-input__password").eq(1).val().length == 0) {
             similarityPassword = true;
             $(".sign-up .form-input__password").eq(1).siblings().eq(2).fadeIn(1000);        
        }
        else {
            similarityPassword = true;
            $(".sign-up .form-input__password").eq(1).siblings().eq(2).fadeIn(1000);      
        }
    }
    //

    //recovery password
    $('.recovery-password-form').submit(function() {
        errorEmail = checkEmail(inputLogin, errorEmail);
        if(errorEmail == false){
            return true;
        } else {
            return false;
        }
    });
    //
    
    //checkout form
    $(".confirmation__button").click(function(){
        langth = 3;
        errorName = checkInput(inputName, langth, errorName);
        errorEmail = checkEmail(inputEmail, errorEmail);
        errorTel = checkTel(inputTel, errorTel);        
        if($(".form-input__delivery:checked").val() == "samovyvoz"){
            if(errorName == false && errorEmail == false && errorTel == false)
            {
                $(".checkout-form").submit();                              
            } 
            else
            {
                return false;                 
            }   
        }
        else{
            errorCity = checkСity(inputCity, errorCity);
            errorAddress = checkAddress(inputAddress, errorAddress);
            if(errorName == false && errorEmail == false && errorTel == false && errorCity == false && errorAddress == false)
            {
                $(".checkout-form").submit();                              
            } 
            else
            {
                return false;                 
            }   
        }
    });
    //

    // form edit personal info
    $('.prof-edit-pers-info').submit(function() { 
        inputPasswordOld =  $(".form-input__password").eq(0);
        inputPasswordNew =  $(".form-input__password").eq(1);
        inputPasswordNewAgain =  $(".form-input__password").eq(2);
        langth = 3;
        errorName = checkInput(inputName, langth, errorName);
        errorEmail = checkEmail(inputEmail, errorEmail);  
        langth = 6;        
        errorPassword = checkInput(inputPasswordOld, langth, errorPassword);
        //errorNewPassword = checkInput(inputPasswordNew, langth, errorNewPassword);

        if(inputPasswordNew.val().length > 0 || inputPasswordNewAgain.val().length > 0){
            errorNewPassword = checkInput(inputPasswordNew, langth, errorNewPassword);
            if(inputPasswordNew.val().length >= 6) 
            {
                if(inputPasswordNew.val() == inputPasswordNewAgain.val()){
                    inputPasswordNewAgain.siblings(".password__error-message").fadeOut(1000);  
                    similarityPassword = false;                  
                }
            }         
            else {
                similarityPassword = true;                 
                inputPasswordNewAgain.siblings(".password__error-message").fadeIn(1000);              
            }      
            if(errorName == false && errorEmail == false && errorPassword == false && errorNewPassword == false && similarityPassword == false){
                return true;               
            } else {
                return false;                 
            }
        }
       else{
            if(errorName == false && errorEmail == false && errorPassword == false){
                return true;               
            } else {
                return false;                 
            }
        } 
    });
    //

    // form backcall
    $('.form-backcall').submit(function() {          
        inputTel = $(".form-backcall .form-input__tel");
        errorTel = checkTel(inputTel, errorTel);       
        if(errorTel == false)
        {
            return true;               
        } 
        else {
            return false;                 
        }            
    }); 
    //

    //form contacts
    $(".feedback-form").submit(function(){
        langth = 3;
        errorName = checkInput(inputName, langth, errorName);
        errorEmail = checkEmail(inputEmail, errorEmail); 
        langth = 5;
        errorMessage = checkInput(inputMessage, langth, errorMessage);
        if(errorName == false && errorEmail == false && errorMessage == false){
            return true;
        } else {
            return false;   
        }      
    });
    //

    //review form
    $(".reviews-form").submit(function(){        
        langth = 3;
        errorMessage = checkInput(inputMessage, langth, errorMessage);
        if(errorTitle == false && errorMessage == false){
            return true;
        } else {
            return false;   
        }  
    });
    //

    //articles form
    $(".articles-form .btn-success").click(function(){
        $(".articles-form-textarea").each(function(){

           $(this).val($(this).parents(".tab-element").children(".editor-container").children(".ql-editor").html())
        });
    });
    //
    
    //order edit form
    $(".submit-order-form").click(function(){
        $(".add-order-product__wrapper input").attr("disabled", "disabled");
        $(".add-order-product__wrapper").slideUp();  
         return true;
    });
    //



    function checkEmail(inputVal, inputError){
        var pattern = new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/i);        
        if(pattern.test($(inputVal).val())) {
            inputError = false;         
            inputVal.siblings().eq(2).fadeOut(1000);
        } else {   
            inputError = true;                 
            inputVal.siblings().eq(2).fadeIn(1000);        
        }
        return inputError;
    }
	function checkInput(inputVal, inputLangth, inputError){
	    let lengthInput = inputVal.val().length; 
	    if(lengthInput >= inputLangth) {      
	        inputError = false;                 
	        inputVal.siblings().eq(2).fadeOut(1000);     
	    } else {
	        inputError = true;
	        inputVal.siblings().eq(2).fadeIn(1000);      
	    }	    
	    return inputError;
	}
    function checkTel(inputVal, inputError){
        var pattern = new RegExp(/(?:\+|\d)[\d\-\(\) ]{8,}\d/g);
        if(pattern.test($(inputVal).val())) {
            inputError = false;         
            inputVal.siblings().eq(2).fadeOut(1000);            
        } else {   
            inputError = true;                 
            inputVal.siblings().eq(2).fadeIn(1000);
        }
        return inputError;
    }
    function checkСity(inputVal, inputError){
        if(inputVal.attr("data-city") !== undefined && inputVal.attr("data-city").length > 0)
        {
            inputError = false; 
            inputVal.siblings(".city__error-message").fadeOut(1000);
        }
        else {   
            inputError = true;                 
            inputVal.siblings(".city__error-message").fadeIn(1000);        
        }
        return inputError;
    }
    function checkAddress(inputVal, inputError){
        if(inputVal.attr("data-address") !== undefined && inputVal.attr("data-address").length > 0)
        {
            inputError = false; 
            inputVal.siblings(".address__error-message").fadeOut(1000);
        }
        else {   
            inputError = true;                 
            inputVal.siblings(".address__error-message").fadeIn(1000);        
        }
        return inputError;
    }    
    
	//

    //sorting
    $(".sort-toggle").click(function(){      
        $(".sort__list").toggle();  
    });
    $(".sort__item").click(function(){
        $('.sort__item').removeClass('sort__item-selected');      
        $(".sort-toggle").html($(this).children().html());   
        $(this).addClass('sort__item-selected');   
        $(this).parents(".sort__list").hide();
    }); 
    $(document).click(function(e){
        if (! $(e.target).parents().hasClass("sort-dropdown")) $(".sort__list").hide();
    });
    //

    //filter
    $(".item-filter__title").click(function (){
        $(this).toggleClass('opened');
        $(this).siblings().slideToggle("slow");
    });
    $(".filter-inp__item").click(function (){
        if($(this).children()[0].checked){
            $(this).children()[0].checked = false;
        }
        else{
            $(this).children()[0].checked = true;
        }      
    });
    //

    //price-range   
    if($(".catalog-wrapper").length > 0){          
        $(".js-range-slider").ionRangeSlider({
        type: "double",
        min: $(".js-range-slider").attr("data-min-price"),
        max: $(".js-range-slider").attr("data-max-price"),  
        skin: "round",
        from: $(".filter-price__from").val(),
        to: $(".filter-price__to").val(),
            onChange: function (data) {
                $(".filter-price__from").val(data.from);
                $(".filter-price__to").val(data.to);          
            }
        });         
    }
    let my_range = $(".js-range-slider").data("ionRangeSlider");      
    $(".filter-price__from").change(function (){        
        my_range.update({            
            from: this.value,
        });
    }); 
    $(".filter-price__to").change(function (){        
        my_range.update({            
            to: this.value,
        });
    });    
    //
    
    //price difference
    if($('.product__price').is('.price__old')){
        let price =$(".product__price").eq(1).attr('data-price');
        let oldPrice = $(".product__price.price__old").attr('data-old-price');      
        $(".discount-value").html(oldPrice-price);
    }
    //

    //change the quantity of product
    let focusoutQuantityInput = false;
    $(".product-card-content .change-quantity").on("click", function() {
        let thisElement = $(this);
        ChangeQuantityClick(thisElement);
    });
    $(".product-card-content .input_quantity-value").on("input", function() {
        let thisElement = $(this);
        ChangeQuantityInput(thisElement);
    }); 
    $(".product-card-content .input_quantity-value").focusout(function() {
        let thisElement = $(this);
        ChangeQuantityFocusout(thisElement);
    });
    window.ChangeQuantityClick = function(thisElement){
        let input = thisElement.siblings('.input_quantity-value');
        if(input.attr("data-type") == "piece"){
            if(thisElement.is(".quantity-minus")){                
                if (input.val() > 1){
                    let quantity = parseFloat(input.val()) - 1;
                    input.val(quantity);
                }
                else{
                    input.val(1);
                }
            }
            else if(thisElement.is(".quantity-plus")){                
                if (isNaN(input.val()) || input.val() == "" || input.val() === null){                   
                   input.val(1);
                }
                else if (input.val() < 1000000 && !focusoutQuantityInput){                     
                    let quantity = parseFloat(input.val()) + 1;
                    input.val(quantity);
                }
            }                     
        }
        else if(input.attr("data-type") == "area"){           
            if(thisElement.is(".quantity-minus")){                
                if (input.val() > parseFloat(input.attr("data-width"))){
                    let quantity = parseFloat(input.val()) - 0.5;
                    input.val(quantity);
                }
                else{
                    input.val(parseFloat(input.attr("data-width")));
                }
            }
            else if(thisElement.is(".quantity-plus")){                
                if (isNaN(input.val()) || input.val() == "" || input.val() === null){
                   input.val(input.attr("data-width"));
                }
                else if (input.val() >= parseFloat(input.attr("data-width")) && input.val() < parseFloat("1000000") && !focusoutQuantityInput){                    
                    let quantity = parseFloat(input.val()) + 0.5;
                    input.val(quantity);                   
                }
                else {if(input.val() < parseFloat(input.attr("data-width")))
                    input.val(parseFloat(input.attr("data-width")));
                }
            }           
        }
        focusoutQuantityInput = false;
    }
    window.ChangeQuantityInput = function(thisElement){        
        if(thisElement.attr("data-type") == "piece"){            
            if (thisElement[0].value.match(/[^0-9]/g)) 
            {
                thisElement[0].value = thisElement[0].value.replace(/[^0-9]/g, '');
            } 
            else if (thisElement[0].value.match(/[^0-9]|^0{1}/g)) 
            {
                thisElement[0].value = thisElement[0].value.replace(/^0+/, '');     
            }
            else if (thisElement[0].value >= 1000000){
                thisElement[0].value = 1000000;
            }
        }
        else if(thisElement.attr("data-type") == "area"){
            thisElement[0].value = thisElement[0].value.replace(/[^.\d]+/g,"").replace( /^([^\.]*\.)|\./g, '$1' ).replace(/^0+/g, '').replace(/^\.+/g, ''); 
            if(thisElement[0].value.match(/\./g)){
                if (thisElement[0].value.match(/^\d+(\.\d{1,1})?$/g))
                {
                    thisElement[0].value = thisElement[0].value.replace(/([0-4]|[6-9]{0,100})?$/g, '');
                }
                else if(thisElement[0].value.match(/^\d+(\.\d{2,2})?$/g))
                {
                    thisElement[0].value = thisElement[0].value.replace(/\d$/g, '');
                }
            }
            else if (thisElement[0].value >= 1000000){
                thisElement[0].value = 1000000;
            }
        }    
    }
    window.ChangeQuantityFocusout = function(thisElement){
        focusoutQuantityInput = true;
        let thisVal = thisElement.val();
        if(thisElement.attr("data-type") == "area"){                           
            if (isNaN(thisVal) || thisVal == "" || thisVal === null || parseFloat(thisVal) < parseFloat(thisElement.attr("data-width")))
            {
                thisElement[0].value = parseFloat(thisElement.attr("data-width"));
            }
        }
        else if(thisElement.attr("data-type") == "piece"){
            if (isNaN(thisVal) || thisVal == "" || thisVal === null || thisVal < 1)
            {
                thisElement[0].value = 1;
            }            
        }
    }
    //

    //
    $(".product-card-content .change-size").on("click", function() {        
        let thisElement = $(this);
        ChangeSizeClick(thisElement);
    });
    $(".product-card-content .input_size-value").on("input", function() {
        let thisElement = $(this);
        ChangeSizeInput(thisElement);
    });
    $(".product-card-content .input_size-value").focusout(function() {
        let thisElement = $(this);
        ChangeSizeFocusout(thisElement);
    });
    window.ChangeSizeClick = function(thisElement){
        let input = thisElement.siblings('.input_size-value');      
        if(thisElement.is(".size-minus") && input.val() > 0.50)
        {            
            let quantity = parseFloat(input.val()) - 0.50;
            input.val(quantity.toFixed(2));
        }
        else if(thisElement.is(".size-plus")){
            if (isNaN(input.val()) || input.val() == "" || input.val() === null){
               input.val(0.50.toFixed(2));
            }
            else if (input.val() < parseFloat("1000000"))
            {
                let quantity = parseFloat(input.val()) + 0.50;
                input.val(quantity.toFixed(2));
            }            
        }  
    }
    window.ChangeSizeInput = function(thisElement){
        thisElement[0].value = thisElement[0].value.replace(/[^.\d]+/g,"").replace( /^([^\.]*\.)|\./g,"$1");
        if(thisElement[0].value.match(/\./g)){
            if(thisElement[0].value.match(/^\d+(\.\d{3,3})?$/g))
            {
                thisElement[0].value = thisElement[0].value.replace(/\d$/g, '');
            }
        }        
        else if (thisElement[0].value >= 1000000){
            thisElement[0].value = 1000000;
        }
    }
    window.ChangeSizeFocusout = function(thisElement){       
        let thisVal = thisElement.val();

        if (isNaN(thisVal) || thisVal == "" || thisVal === null || parseFloat(thisVal) < parseFloat(0.1))
        {
            thisElement[0].value = parseFloat(0.1);
        }   
    }
    //

    //scroll totall bill
    if ($(".main").find(".checkout").length == 1){
        let checkoutOffset = $('.checkout-content').offset().top;
        let checkoutHeight = $('.checkout-content').outerHeight();
        let billHeight = $('.totall-bill').outerHeight();
        let billOffsetTop = $('.totall-bill').offset().top;
        let paddingTop;

        movingTotallBill();

        $(window).scroll(function (){
            checkoutHeight = $('.checkout-content').outerHeight();
            movingTotallBill();
        })
        function movingTotallBill(){
            if(window.innerWidth >= 768){
                if ($(window).scrollTop() > billOffsetTop)
                {
                    if($(window).scrollTop() < checkoutOffset + checkoutHeight - billHeight)
                    {
                        $('.totall-bill').css({
                            position: 'fixed',
                            top: 0
                        });
                    }
                    else
                    {
                        $('.totall-bill').css({
                            position: 'absolute',
                            top: checkoutHeight - billHeight
                        });
                    }
                }
                else
                {
                    $('.totall-bill').css({
                        position: 'static',
                        top: 'auto'
                    });
                }
            }
            else{
                $('.totall-bill').css({
                    position: 'static',
                    top: 'auto'
                });
            }
        }
    }
    //

    //address toggle
    $(".form-input__delivery").click(function(){
        let delivery = $(this).val();
        $(".form-input__city").val("");
        $(".form-input__address").val("");
        if(delivery == "samovyvoz"){ 
            $(".checkout-step__title.city").css("text-decoration", "line-through");
            $(".form-section.city").slideUp("slow");
            $(".form-input__city").attr("disabled", "disabled");
            $(".form-input__address").attr("disabled", "disabled");
        }
        else{
            $(".checkout-step__title.city").css("text-decoration", "none");
            $(".form-section.city").slideDown("slow");
            $('.form-input__city').removeAttr("disabled");
            $('.form-input__address').removeAttr("disabled");
        }       
    });
    //

    //order history detail toggle
    $(".order-history__item").click(function(){       
        $(this).toggleClass("opened");
        $(this).children(".order-history__details").eq(0).children(".order-history__details-inner.order-history-products__list").slideToggle("slow");
        $(this).children(".order-history__status").eq(0).children(".order-history__status-inner.profile-order-info__list").slideToggle("slow");
    });
    //

    // header phones toggle
    $(".header-phones").mouseout(function(){
        $(this).css("overflow", "");
        $(".header-phones__list").css("box-shadow", "");
    }).on("mouseover click", function(){       
        $(this).css("overflow", "visible");
        $(".header-phones__list").css("box-shadow", "0px 3px 17px #98989899");
    });
    if($(".header-phones").length == 1){
        $(document).click(function (e){            
            if (!$(".header-phones").is(e.target) && !$(".header-phones *").is(e.target)) 
            {                
                $(".header-phones").css("overflow", "");
                $(".header-phones__list").css("box-shadow", "")
            }
        });
    }
    //

    //backcall toggle
    $(".backcall-toggle, .feedback-button").click(function(){
        backcallShow();
    });  
    window.backcallShow = function() {
        $(".popup__bg").show();
        $(".backcall-wrapper").show();       
    }
    $(".popup__bg").click(function(e){
        if($(".popup__bg").is(e.target) || $(".popup-close__button").is(e.target) || $("button.popup-cart-btn-link").is(e.target)){
            $(".popup__bg").hide();
            $(".backcall-wrapper").hide(); 
            $(".popup-cart-wrapper").hide();
            $(".successful-buy-wraper").hide();           
        }       
    });    
    //

    //add to cart popup
    $(".add-to-cart, .product__add-to-cart").click(function(){
        $(".popup__bg").show();
        $(".popup-cart-wrapper").show();
    });
    //

    //status dropdown    
    $(".status-toggle").click(function(){
        let thisElement = $(this);
        statusToggle(thisElement);
    });
    window.statusToggle = function(thisElement){
        let status = thisElement.siblings(".status__list").attr("style");       
        if (status == "display: none;"){
            $('.status__list').hide();
            thisElement.siblings(".status__list").show();
            status = thisElement.siblings(".status__list").attr("style");  
        }
        else{
            thisElement.siblings(".status__list").hide();
            status = thisElement.siblings(".status__list").attr("style");
        }  
    }

    $(".order-edit .status__item, .order-table .status__item, .products-table .status__item").click(function(e){        
        let thisElement = $(this);
        statusValueToggle(thisElement);
    });
    window.statusValueToggle = function(thisElement){
        let value = thisElement.val(); 
        switch (value) {
            case 1:
                $(".order-status")[0].value = "in processing";                
            break;
            case 2:
                $(".order-status")[0].value = "in progress";              
            break;
            case 3:
                $(".order-status")[0].value = "completed";               
            break;
            case 4:
                $(".order-status")[0].value = "fail";              
            break;
        }           
        let classList = thisElement.parents(".status__list").siblings(".status-toggle").attr('class').split(/\s+/);
        thisElement.parents(".status__list").siblings(".status-toggle").removeClass(classList[1]);
        thisElement.parents(".status__list").siblings(".status-toggle").removeClass(classList[2]);
        classList = thisElement.attr('class').split(/\s+/);
        thisElement.parents(".status__list").siblings(".status-toggle").addClass(classList[1]);
        thisElement.parents(".status__list").siblings(".status-toggle").addClass(classList[2]);
        thisElement.parents(".status__list").siblings(".status-toggle").html(thisElement.html());
        thisElement.parents(".status__list").toggle();         
    }

    if ($(".order-edit, .order-table, .product-edit, .products-table").length == 1){
        $(document).click(function (e){
            if (!$(".status__item").is(e.target) && !$(".status-toggle").is(e.target)) 
            {
                $(".status__list").hide();
            }
        });       
    }

    $(".product-edit .status__item").click(function(e){
        let thisElement = $(this);
        let value = thisElement.val();        
        switch (value) {
            case 1:
                $(".product-status")[0].value = "true";//on sale                
            break;
            case 2:
                $(".product-status")[0].value = "false";//not on sale              
            break;            
        }           
        let classList = thisElement.parents(".status__list").siblings(".status-toggle").attr('class').split(/\s+/);
        thisElement.parents(".status__list").siblings(".status-toggle").removeClass(classList[1]);
        thisElement.parents(".status__list").siblings(".status-toggle").removeClass(classList[2]);
        classList = thisElement.attr('class').split(/\s+/);
        thisElement.parents(".status__list").siblings(".status-toggle").addClass(classList[1]);
        thisElement.parents(".status__list").siblings(".status-toggle").addClass(classList[2]);
        thisElement.parents(".status__list").siblings(".status-toggle").html(thisElement.html());
        thisElement.parents(".status__list").toggle();
    });    
    //

    //sidebar dropdown toggle
    $(".sidebar__item").click(function(){
        let status = $(this).children(".sidebar__item-dropdown").attr("style");        
        if (status == "display: none;"){
            $('.sidebar__item-dropdown').slideUp()
            $(this).children(".sidebar__item-dropdown").slideDown()
            status = $(this).children(".sidebar__item-dropdown").attr("style");  
        }
        else{
            $(this).children(".sidebar__item-dropdown").slideUp();
            status = $(this).children(".sidebar__item-dropdown").attr("style");  
        }  
    })
    if ($(".admin").find(".admin-sidebar").length == 1){
        $(document).click(function (e){
            if (!$(".sidebar__item-dropdown").is(e.target) && !$(".sidebar__item-link").is(e.target) 
                && !$(".sidebar__item-dropdown").has(e.target).length === 0) 
            {
                $(".sidebar__item-dropdown").slideUp();
            }
        });
    }
    //

    //header navbar dropdown toggleClass
    $(".navbar-header__toggle").click(function(){
        $(".navbar-header__list").slideToggle();
    });
    if ($(".admin").find(".admin-header").length == 1){
        $(document).click(function (e){
            if (!$(".navbar-header__toggle").is(e.target) && !$(".navbar-header__list").is(e.target) && !$(".navbar-header__toggle").has(e.target).length === 0) 
            {
                $(".navbar-header__list").slideUp();
            }
        });
    }
    //

    //admin form toggle review
    $(".review .btn-success").click(function(){      
        $(this).parents(".reviews__item-wraper").siblings(".reviews__reply").slideToggle();
    });
    //

    // editing form connection
    if($(".admin-content-main").find(".articles-form").length == 1){
        var quill = new Quill('#editor-container__one', {
            modules: {
                toolbar: [
                [{ 'size': ['small', false, 'large', 'huge'] }],
                ['bold', 'italic','underline', 'strike'],
                ['link', 'blockquote'],
                [{ list: 'ordered' }, { list: 'bullet' }],
                [{ 'color': [] }, { 'background': [] }],
                [{ 'align': [] }],
                ['clean'] 
                ]
            },
            placeholder: 'Введдите текст',
            theme: 'snow'
        });  
        var quill = new Quill('#editor-container__two', {
            modules: {
                toolbar: [
                [{ 'size': ['small', false, 'large', 'huge'] }],
                ['bold', 'italic','underline', 'strike'],
                ['link', 'blockquote'],
                [{ list: 'ordered' }, { list: 'bullet' }],
                [{ 'color': [] }, { 'background': [] }],
                [{ 'align': [] }],
                ['clean'] 
                ]
            },
            placeholder: 'Введдите текст',
            theme: 'snow'
        });       
        var quill = new Quill('#editor-container__three', {
            modules: {
                toolbar: [
                [{ 'size': ['small', false, 'large', 'huge'] }],
                ['bold', 'italic','underline', 'strike'],
                ['link', 'blockquote'],
                [{ list: 'ordered' }, { list: 'bullet' }],
                [{ 'color': [] }, { 'background': [] }],
                [{ 'align': [] }],
                ['clean'] 
                ]
            },
            placeholder: 'Введдите текст',
            theme: 'snow'
        });
        $(".ql-editor").each(function(){
            $(this).html($(this).parents(".tab-element").children(".articles-form-textarea").val());
            
        });
    }
    //

    // upload img visual
    $(".product-edit .upload__img-multiple").change(function(){
        if (this.files.length <= 4 ) 
        {   
            $('.upload__img-wrapper label').remove();
            for(let i = 0; i<this.files.length; i++){
                var reader = new FileReader();
                reader.onload = function (e) {
                    $(".upload__img-wrapper").prepend('<label for="upload__img"><img src="'+e.target.result+'"></label>')
                }; 
                reader.readAsDataURL(this.files[i]);
            }
        }
        else{
            $(".upload__img-multiple")[0].value = "";
        }
    });
    $(".product-edit .upload__img").change(function(){
        if (this.files && this.files[0]) 
        {
            thisImg = $(this).siblings().children();
            var reader = new FileReader();
            reader.onload = function (e) {
                thisImg.attr('src', e.target.result);
            };
                reader.readAsDataURL(this.files[0]);
        }
    });

    $(".upload__slider-img .upload__slider-img-multiple").change(function(){
        if (this.files.length <= 6 ) 
        {   
            $('.upload__slider-img-wrapper label').remove();
            for(let i = 0; i<this.files.length; i++){
                var reader = new FileReader();
                reader.onload = function (e) {
                    $(".upload__slider-img-wrapper").prepend('<label for="upload__img"><img src="'+e.target.result+'"></label>')
                }; 
                reader.readAsDataURL(this.files[i]);
            }
        }
        else{
            $(".upload__slider-img-multiple")[0].value = "";
        }
    });      
    //

    //language tabs 
    $(".product-edit .tab-button__item").click(function(){      
        if(!$(this).is(".btn-info")){
            $(this).parents(".tab-button__list").children(".tab-button__item").removeClass("btn-info");
            $(this).parents(".tab-button__list").children(".tab-button__item").addClass("btn-light");
            $(this).removeClass("btn-light");
            $(this).addClass("btn-info");               
            $(this).parents(".tab-button__list").nextUntil(".edit__title").fadeTo(500, 0);
            setTimeout(function() {
                $(this).parents(".tab-button__list").nextUntil(".edit__title").css({ 'position' : 'absolute', 'visibility' : 'hidden' });
            }.bind(this),500);
            setTimeout(function() {                
                $(this).parents(".tab-button__list").nextUntil(".edit__title").eq($(this).index()).css({ 'position' : 'static', 'visibility' : 'visible' });
            }.bind(this),500);
            $(this).parents(".tab-button__list").nextUntil(".edit__title").eq($(this).index()).fadeTo(500, 1);
        }       
    });

    $(".articles-form .tab-button__item").click(function () {
        if (!$(this).is(".btn-info")) {
            $(this).parents(".tab-button__list").children(".tab-button__item").removeClass("btn-info");
            $(this).parents(".tab-button__list").children(".tab-button__item").addClass("btn-light");
            $(this).removeClass("btn-light");
            $(this).addClass("btn-info");
            $(".tab-element").fadeTo(500, 0);
            setTimeout(function () {
                $(".tab-element").css({ 'position': 'absolute', 'visibility': 'hidden' });
            }.bind(this), 500);
            setTimeout(function () {
                $(".tab-element").eq($(this).index()).css({ 'position': 'static', 'visibility': 'visible' });   
                $(".tab-element").eq($(this).index()+3).css({ 'position': 'static', 'visibility': 'visible' }); 
            }.bind(this), 500);
            $(".tab-element").eq($(this).index()).fadeTo(500, 1);
            $(".tab-element").eq($(this).index()+3).fadeTo(500, 1);
        }
    });

    //add order product toggle
    $(".add-order-product__title").click(function(){
        if($(".add-order-product__wrapper input").attr("disabled")){ 
            $(".add-order-product__wrapper").slideDown();             
            $(".add-order-product__wrapper input").removeAttr("disabled");
        }
       else{            
            $(".add-order-product__wrapper input").attr("disabled", "disabled");
            $(".add-order-product__wrapper").slideUp();  
       }
    });
    //

    //edit stock toggle    
    $(".edit-stock__toggle").on("change", function(){
        if($(".product-edit__stock")[0].checked == true){
            $(".product-edit-stock").slideDown();
            $(".product-edit-stock input").removeAttr("disabled");
        }
        else{            
            $(".product-edit-stock input").attr("disabled", "disabled");
            $(".product-edit-stock").slideUp();
           
        }
    });
    //

    //filter counter
    $(".filter-inp__item").click(function(){       
        let padding = $(this).offset().top - $(".filter-form").offset().top - 4;       
        $(".filter-counter-wrapper").show();
        $(".filter-counter-wrapper").css({"top" : padding});
    });
    if($(".filter-counter-wrapper").length == 1){
        $(document).click(function (e){            
            if (!$(".filter-inp__item").is(e.target) && !$(".filter-inp__item *").is(e.target)) 
            {
                $(".filter-counter-wrapper").hide();
            }
        });
    }

    //filter toggle
    $(".filter__toggle").click(function(){
        $(".filter-form").slideToggle();
    })
    //

    //product card hover
    $(".catalog__item-wrapper").hover(function() {
        $(this).children(".catalog__item-extra-info-wrapper").children(".catalog__item-extra-info").css("margin-top",$(this).outerHeight()-10)
    });
    // 

    //langs
    let langValue = document.cookie.match(new RegExp("(?:^|; )" + "lang".replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"))
    if (langValue != null)
    {
        if (langValue[1] == "ru") {
            $(".lang-switch__item").eq(0).addClass("lang__current");
            if($(".cart__header").length >= 1)
            {
                $(".cart-product-price").addClass("cart-price__ru");
                $(".cart-count").addClass("cart-count__ru");
                $(".cart-product-total-price").addClass("cart-total-price__ru");
            }
        }
        else if (langValue[1] == "uk") {
            $(".lang-switch__item").eq(1).addClass("lang__current");
            if($(".cart__header").length >= 1)
            {
                $(".cart-product-price").addClass("cart-price__ua");
                $(".cart-count").addClass("cart-count__ua");
                $(".cart-product-total-price").addClass("cart-total-price__ua");
            }
        }
        else if (langValue[1] == "en") {
            $(".lang-switch__item").eq(2).addClass("lang__current");
            if($(".cart__header").length >= 1)
            {
                $(".cart-product-price").addClass("cart-price__eng");
                $(".cart-count").addClass("cart-count__eng");
                $(".cart-product-total-price").addClass("cart-total-price__eng");
            }
        }
    }
    else
    {
        $(".lang-switch__item").eq(0).addClass( "lang__current");
    }
    // 

    //subcategoty
    showSubcategory($(".product-category__item").eq(0).text());
    $(".product-category-list").on("change", function(){
        let selectValue = $(".product-category__item[value="+ "'" + $(this).val() + "'" +"]").text();       
        showSubcategory(selectValue);
    })
    function showSubcategory(Value){
        let selectValue = Value;
        switch (selectValue) {  
            case "Тенты ПВХ":                   
                $(".product-edit-subcategory").show();
                $(".product-subcategory__item").removeAttr("disabled");
                $(".product-edit__type").attr("disabled","");
                $(".product-edit__type-toggle").hide();
                break; 
            case "Швейное производство":
                $(".product-subcategory__item").attr("disabled","");
                $(".product-edit-subcategory").hide();
                $(".product-edit__type-toggle").show();
                $(".product-edit__type").removeAttr("disabled");
                break;
            default:
                $(".product-subcategory__item").attr("disabled","");
                $(".product-edit-subcategory").hide();
                $(".product-edit__type").attr("disabled","");
                $(".product-edit__type-toggle").hide();
                break;
        }
    }
    //


    //toggle additional information
    $(".additional-information").click(function(){        
        $(this).nextUntil(".edit__title",".tab-button__list").slideToggle();
        $(this).nextUntil(".edit__title",".additional-information__more").slideToggle();       
        if($(this).nextUntil(".edit__title",".tab-button__list").height() > 0){

            $(this).nextUntil(".edit__title",".tab-element").css({ 'position' : 'absolute', 'visibility' : 'hidden' });          
            $(this).nextUntil(".edit__title",".tab-button__list").children().removeClass("btn-light");
            $(this).nextUntil(".edit__title",".tab-button__list").children().removeClass("btn-info");
            $(this).nextUntil(".edit__title",".tab-button__list").children().eq(0).addClass("btn-info");
        }
        else{
            $(this).nextUntil(".edit__title",".tab-element").eq(0).css({ 'position' : 'static', 'visibility' : 'visible','opacity': '1' });
        }
    });
    //    
})