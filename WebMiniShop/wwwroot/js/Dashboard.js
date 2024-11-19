window.addEventListener('DOMContentLoaded', event => {

    // Toggle the side navigation
    const sidebarToggle = document.body.querySelector('#sidebarToggle');
    if (sidebarToggle) {
        // Uncomment Below to persist sidebar toggle between refreshes
        // if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
        //     document.body.classList.toggle('sb-sidenav-toggled');
        // }
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });
    }

    // Handle TrangThai/Index link click
    const trangThaiLink = document.body.querySelector('#trangthai');
    if (trangThaiLink) {
        trangThaiLink.addEventListener('click', event => {
            event.preventDefault();
            loadTrangThaiContent();
        });
    }

    // Handle HoaDon/Index link click
    const hoaDonLink = document.body.querySelector('#hoadon');
    if (hoaDonLink) {
        hoaDonLink.addEventListener('click', event => {
            event.preventDefault();
            loadHoaDonContent();
        });
    }

    // Handle HangHoa/Index link click
    const hangHoaLink = document.body.querySelector('#hanghoa');
    if (hangHoaLink) {
        hangHoaLink.addEventListener('click', event => {
            event.preventDefault();
            loadHangHoaContent();
        });
    }

    // Handle KhuyenMai/Index link click
    const khuyenMaiLink = document.body.querySelector('#khuyenmai');
    if (khuyenMaiLink) {
        khuyenMaiLink.addEventListener('click', event => {
            event.preventDefault();
            loadKhuyenMaiContent();
        });
    }

    // Handle User/Index link click
    const userLink = document.body.querySelector('#user');
    if (userLink) {
        userLink.addEventListener('click', event => {
            event.preventDefault();
            loadUserContent();
        });
    }

    // Handle NhaCungCap/Index link click
    const nhaCungCapLink = document.body.querySelector('#nhacungcap');
    if (nhaCungCapLink) {
        nhaCungCapLink.addEventListener('click', event => {
            event.preventDefault();
            loadNhaCungCapContent();
        });
    }

    // Handle Loai/Index link click
    const loaiLink = document.body.querySelector('#loai');
    if (loaiLink) {
        loaiLink.addEventListener('click', event => {
            event.preventDefault();
            loadLoaiContent(); 
        });
    }

    // Handle LichSuGiaoDich/Index link click
    const lichSuGiaoDichLink = document.body.querySelector('#lichsugiaodich');
    if (lichSuGiaoDichLink) {
        lichSuGiaoDichLink.addEventListener('click', event => {
            event.preventDefault();
            loadLichSuGiaoDichContent();
        });
    }

    // Handle NhapKho/Index link click
    const nhapKhoLink = document.body.querySelector('#nhapkho');
    if (nhapKhoLink) {
        nhapKhoLink.addEventListener('click', event => {
            event.preventDefault();
            loadNhapKhoContent();
        });
    }

    // Handle TonKho/Index link click
    const tonKhoLink = document.body.querySelector('#tonkho');
    if (tonKhoLink) {
        tonKhoLink.addEventListener('click', event => {
            event.preventDefault();
            loadTonKhoContent();
        });
    }

});

window.addEventListener('DOMContentLoaded', event => {
    // Simple-DataTables
    // https://github.com/fiduswriter/Simple-DataTables/wiki

    const datatablesSimple = document.getElementById('datatablesSimple');
    if (datatablesSimple) {
        new simpleDatatables.DataTable(datatablesSimple);
    }
});

function loadTrangThaiContent() {
    const main = document.querySelector('main');
    if (main) {
        fetch('/Admin/TrangThai')
            .then(response => response.text())
            .then(data => {
                main.innerHTML = data;

                // Khởi tạo lại DataTables
                const datatablesSimple = document.getElementById('datatablesSimple');
                if (datatablesSimple) {
                    new simpleDatatables.DataTable(datatablesSimple);
                }

                // Khởi tạo lại các thư viện JavaScript khác nếu cần

                // Thay đổi URL trên thanh tìm kiếm
                history.pushState(null, '', '/Admin/TrangThai');
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }
}

function loadHoaDonContent() {
    const main = document.querySelector('main');
    if (main) {
        fetch('/Admin/HoaDon')
            .then(response => response.text())
            .then(data => {
                main.innerHTML = data;

                // Khởi tạo lại DataTables
                const datatablesSimple = document.getElementById('datatablesSimple');
                if (datatablesSimple) {
                    new simpleDatatables.DataTable(datatablesSimple);
                }

                // Khởi tạo lại các thư viện JavaScript khác nếu cần

                // Thay đổi URL trên thanh tìm kiếm
                history.pushState(null, '', '/Admin/HoaDon');
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }
}

function loadHangHoaContent() {
    const main = document.querySelector('main');
    if (main) {
        fetch('/Admin/HangHoa')
            .then(response => response.text())
            .then(data => {
                main.innerHTML = data;

                // Khởi tạo lại DataTables
                const datatablesSimple = document.getElementById('datatablesSimple');
                if (datatablesSimple) {
                    new simpleDatatables.DataTable(datatablesSimple);
                }

                // Khởi tạo lại các thư viện JavaScript khác nếu cần

                // Thay đổi URL trên thanh tìm kiếm
                history.pushState(null, '', '/Admin/HangHoa');
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }
}

function loadKhuyenMaiContent() {
    const main = document.querySelector('main');
    if (main) {
        fetch('/Admin/KhuyenMai')
            .then(response => response.text())
            .then(data => {
                main.innerHTML = data;

                // Khởi tạo lại DataTables
                const datatablesSimple = document.getElementById('datatablesSimple');
                if (datatablesSimple) {
                    new simpleDatatables.DataTable(datatablesSimple);
                }

                // Khởi tạo lại các thư viện JavaScript khác nếu cần

                // Thay đổi URL trên thanh tìm kiếm
                history.pushState(null, '', '/Admin/KhuyenMai');
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }
}

function loadUserContent() {
    const main = document.querySelector('main');
    if (main) {
        fetch('/Admin/User')
            .then(response => response.text())
            .then(data => {
                main.innerHTML = data;

                // Khởi tạo lại DataTables
                const datatablesSimple = document.getElementById('datatablesSimple');
                if (datatablesSimple) {
                    new simpleDatatables.DataTable(datatablesSimple);
                }

                // Khởi tạo lại các thư viện JavaScript khác nếu cần

                // Thay đổi URL trên thanh tìm kiếm
                history.pushState(null, '', '/Admin/User');
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }
}

function loadNhaCungCapContent() {
    const main = document.querySelector('main');
    if (main) {
        fetch('/Admin/NhaCungCap')
            .then(response => response.text())
            .then(data => {
                main.innerHTML = data;

                // Khởi tạo lại DataTables
                const datatablesSimple = document.getElementById('datatablesSimple');
                if (datatablesSimple) {
                    new simpleDatatables.DataTable(datatablesSimple);
                }

                // Khởi tạo lại các thư viện JavaScript khác nếu cần

                // Thay đổi URL trên thanh tìm kiếm
                history.pushState(null, '', '/Admin/NhaCungCap');
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }
}

function loadLoaiContent() {
    const main = document.querySelector('main');
    if (main) {
        fetch('/Admin/Loai')
            .then(response => response.text())
            .then(data => {
                main.innerHTML = data;

                // Khởi tạo lại DataTables
                const datatablesSimple = document.getElementById('datatablesSimple');
                if (datatablesSimple) {
                    new simpleDatatables.DataTable(datatablesSimple);
                }

                // Khởi tạo lại các thư viện JavaScript khác nếu cần

                // Thay đổi URL trên thanh tìm kiếm
                history.pushState(null, '', '/Admin/Loai');
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }
}

function loadLichSuGiaoDichContent() {
    const main = document.querySelector('main');
    if (main) {
        fetch('/Admin/LichSuGiaoDich')
            .then(response => response.text())
            .then(data => {
                main.innerHTML = data;

                // Khởi tạo lại DataTables
                const datatablesSimple = document.getElementById('datatablesSimple');
                if (datatablesSimple) {
                    new simpleDatatables.DataTable(datatablesSimple);
                }

                // Khởi tạo lại các thư viện JavaScript khác nếu cần

                // Thay đổi URL trên thanh tìm kiếm
                history.pushState(null, '', '/Admin/LichSuGiaoDich');
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }
}

function loadNhapKhoContent() {
    const main = document.querySelector('main');
    if (main) {
        fetch('/Admin/NhapKho')
            .then(response => response.text())
            .then(data => {
                main.innerHTML = data;

                // Khởi tạo lại DataTables
                const datatablesSimple = document.getElementById('datatablesSimple');
                if (datatablesSimple) {
                    new simpleDatatables.DataTable(datatablesSimple);
                }

                // Khởi tạo lại các thư viện JavaScript khác nếu cần

                // Thay đổi URL trên thanh tìm kiếm
                history.pushState(null, '', '/Admin/NhapKho');
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }
}

function loadTonKhoContent() {
    const main = document.querySelector('main');
    if (main) {
        fetch('/Admin/TonKho')
            .then(response => response.text())
            .then(data => {
                main.innerHTML = data;

                // Khởi tạo lại DataTables
                const datatablesSimple = document.getElementById('datatablesSimple');
                if (datatablesSimple) {
                    new simpleDatatables.DataTable(datatablesSimple);
                }

                // Khởi tạo lại các thư viện JavaScript khác nếu cần

                // Thay đổi URL trên thanh tìm kiếm
                history.pushState(null, '', '/Admin/ TonKho');
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }
}
