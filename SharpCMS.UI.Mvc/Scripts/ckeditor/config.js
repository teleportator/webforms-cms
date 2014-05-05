/*
Copyright (c) 2003-2011, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
	config.format_tags = 'p;h1;h2;h3;h4';
	config.width = "720";
	config.toolbarCanCollapse = false;
	config.toolbar =
		[
			{ name: 'document', items: ['Source'] },
			{ name: 'clipboard', items: ['Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
			{ name: 'styles', items: ['Format'] },
			{ name: 'basicstyles', items: ['Bold', 'Italic', 'Underline'] },
			{ name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight'] },
			{ name: 'links', items: ['Link', 'Unlink'] },
			{ name: 'insert', items: ['Image'] },
			{ name: 'tools', items: ['Maximize', 'ShowBlocks'] }
		];
	config.filebrowserBrowseUrl = "/scripts/ckfinder/ckfinder.html";
	config.filebrowserImageBrowseUrl = "/scripts/ckfinder/ckfinder.html?type=Images";
	config.filebrowserUploadUrl = "/scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
	config.filebrowserImageUploadUrl = "/scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
	config.filebrowserWindowWidth = "1000";
	config.filebrowserWindowHeight = "700";
};
