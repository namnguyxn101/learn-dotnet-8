# Webpack

## Sử dụng Webpack để đóng gói file JS, CSS, SCSS
Ở ví dụ trước đã sử dụng BuildBundlerMinifier để gộp CSS, JS. Tuy nhiên để linh hoạt hơn từ phần này sẽ sử dụng Webpack với .NET Core, sẽ thực hiện từng bước để tích hợp BootStrap, JQuery và một file nguồn SCSS tự động build thành CSS.

Gõ các lệnh sau để cài webpack:
```bash
npm init -y                                         # tạo file package.json cho dự án
npm i -D webpack webpack-cli                        # cài đặt Webpack
npm i node-sass postcss-loader postcss-preset-env   # cài đặt các gói để làm việc với SCSS
npm i sass-loader css-loader cssnano                # cài đặt các gói để làm việc với SCSS, CSS
npm i mini-css-extract-plugin cross-env file-loader # cài đặt các gói để làm việc với SCSS
npm install copy-webpack-plugin                     # cài đặt plugin copy file cho Webpack
npm install npm-watch                               # package giám sát file  thay đổi

npm install bootstrap@4.6.0                         # cài đặt thư viện bootstrap
npm install jquery@3.6.0                            # cài đặt Jquery
npm install popper.js@1.16.1                        # thư viện cần cho bootstrap
```

Để nạp js, css vào wwwroot, chạy lệnh:
```bash
npm run build
```
Nếu muốn npm tự nạp lại khi lưu file, chạy lệnh:
```bash
npm run watch
```