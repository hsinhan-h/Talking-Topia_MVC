


$(document).ready(function () {
    console.log('���b�[�� "�y���ǲ�" ���');
    // �w�]��� "�y���ǲ�" ���ҵ{
    loadCourses("�y���ǲ�");

    // ��ť tab �I���ƥ�
    $('.lh-layout-tab').on('click', function () {
        // �����Ҧ� tab �� active �˦�
        $('.lh-layout-tab').removeClass('active');
        // ����e�I���� tab �K�[ active �˦�
        $(this).addClass('active');

        // ��������� category �W�� (����)
        var category = $(this).data('category');
                console.log('�[����: ' + category);  // �ոեΡA��ܷ�e�[��������

        loadCourses(category);
    });

    // �o�e AJAX �ШD����������������ҵ{
    function loadCourses(category) {
        $.ajax({
            url: '/Home/GetCoursesByCategory',
            type: 'GET',
            data: { categoryName: category }, 
            success: function (data) {
                renderCourses(data);  // ���\����ƾګ��V
            },
            error: function (err) {
                console.error("Error fetching courses:", err);
            }
        });
    }

    // ��V�ҵ{�d��
    function renderCourses(courses) {
        var courseList = $('#lh-layout-course-list');
        courseList.empty(); // �M�Ų{�����e

        // �ʺA��V�ҵ{
        courses.forEach(function (course) {
            var courseItem = `
            <a href="/Course/CourseList?page=1&subject=${encodeURIComponent(course.subjectName)}&sortOption=default" class="lh-layout-course-item">
                <img src="${course.tutorHeadShotImage}" alt="Teacher's Image" />
                <h3>${course.subjectName}</h3>

            </a>
        `;
            courseList.append(courseItem); // �ʺA�K�[�C�ӽҵ{�d��
        });
    }
});
