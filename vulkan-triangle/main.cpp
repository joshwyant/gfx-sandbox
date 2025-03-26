#include <vulkan/vulkan.h>
#include <GLFW/glfw3.h>
#include <iostream>
#include <vector>
#include <stdexcept>
#include <fstream>

#define GLFW_EXPOSE_NATIVE_COCOA
#include <GLFW/glfw3native.h>

#include <vulkan/vulkan_macos.h>

#include <objc/objc.h>
#include <objc/message.h>
#include <QuartzCore/CAMetalLayer.h>

#define WIDTH 800
#define HEIGHT 600

GLFWwindow *window;

VkInstance instance;
VkSurfaceKHR surface;

void setMetalLayerForWindow(GLFWwindow *window)
{
    id nsWindow = glfwGetCocoaWindow(window);
    SEL contentViewSel = sel_registerName("contentView");
    id contentView = ((id(*)(id, SEL))objc_msgSend)(nsWindow, contentViewSel);

    Class metalLayerClass = objc_getClass("CAMetalLayer");
    id metalLayer = ((id(*)(id, SEL))objc_msgSend)((id)metalLayerClass, sel_registerName("alloc"));
    metalLayer = ((id(*)(id, SEL))objc_msgSend)(metalLayer, sel_registerName("init"));

    ((void (*)(id, SEL, id))objc_msgSend)(contentView, sel_registerName("setLayer:"), metalLayer);
    //((void (*)(id, SEL, BOOL))objc_msgSend)(contentView, sel_registerName("setWantsLayer:"), YES);

    id layer = ((id(*)(id, SEL))objc_msgSend)(contentView, sel_registerName("layer"));
    Class actualClass = object_getClass(layer);
    const char *className = class_getName(actualClass);
    std::cout << "Layer class: " << className << std::endl;

    CGFloat width = WIDTH;
    CGFloat height = HEIGHT;
    ((void (*)(id, SEL, CGFloat))objc_msgSend)(metalLayer, sel_registerName("setContentsScale:"), 1.0);
}

void initWindow()
{
    glfwInit();
    glfwWindowHint(GLFW_CLIENT_API, GLFW_NO_API); // disable opengl
    window = glfwCreateWindow(WIDTH, HEIGHT, "Vulkan Triangle", nullptr, nullptr);
    if (!window)
    {
        throw std::runtime_error("failed to create window!");
    }
}

void initVulkan()
{
    VkApplicationInfo appInfo{};
    appInfo.sType = VK_STRUCTURE_TYPE_APPLICATION_INFO;
    appInfo.pApplicationName = "Vulkan Triangle";
    appInfo.applicationVersion = VK_MAKE_VERSION(1, 0, 0);
    appInfo.pEngineName = "NoEngine";
    appInfo.engineVersion = VK_MAKE_VERSION(1, 0, 0);
    appInfo.apiVersion = VK_API_VERSION_1_0;

    const char *extensions[] = {
        "VK_KHR_surface",
        "VK_MVK_macos_surface",
        "VK_KHR_portability_enumeration"};
    VkInstanceCreateInfo createInfo{};
    createInfo.sType = VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO;
    createInfo.pApplicationInfo = &appInfo;
    createInfo.enabledExtensionCount = 3;
    createInfo.ppEnabledExtensionNames = extensions;
    createInfo.flags = VK_INSTANCE_CREATE_ENUMERATE_PORTABILITY_BIT_KHR;

    for (uint32_t i = 0; i < 3; ++i)
    {
        std::cout << "Requested Extension: " << extensions[i] << std::endl;
    }

    uint32_t count = 0;
    vkEnumerateInstanceExtensionProperties(nullptr, &count, nullptr);
    std::vector<VkExtensionProperties> exts(count);
    vkEnumerateInstanceExtensionProperties(nullptr, &count, exts.data());

    std::cout << "Available Vulkan extensions:\n";
    for (const auto &e : exts)
    {
        std::cout << "  " << e.extensionName << std::endl;
    }

    vkEnumerateInstanceLayerProperties(&count, nullptr);
    std::vector<VkLayerProperties> layers(count);
    vkEnumerateInstanceLayerProperties(&count, layers.data());

    std::cout << "Available Vulkan layers:\n";
    for (const auto &l : layers)
    {
        std::cout << "  " << l.layerName << std::endl;
    }

    VkResult result = vkCreateInstance(&createInfo, nullptr, &instance);
    if (result != VK_SUCCESS)
    {
        std::cerr << "vkCreateInstance failed with code: " << result << std::endl;
        throw std::runtime_error("failed to create instance!");
    }

    // result = glfwCreateWindowSurface(instance, window, nullptr, &surface);
    // if (result != VK_SUCCESS)
    // {
    //     std::cerr << "glfwCreateWindowSurface failed with code: " << result << std::endl;
    //     throw std::runtime_error("failed to create window surface!");
    // }

    VkMacOSSurfaceCreateInfoMVK surfaceCreateInfo{};
    surfaceCreateInfo.sType = VK_STRUCTURE_TYPE_MACOS_SURFACE_CREATE_INFO_MVK;
    id nsWindow = glfwGetCocoaWindow(window);
    id contentView = ((id(*)(id, SEL))objc_msgSend)(nsWindow, sel_registerName("contentView"));
    id metalLayer = ((id(*)(id, SEL))objc_msgSend)(contentView, sel_registerName("layer"));
    surfaceCreateInfo.pView = (void *)metalLayer;

    result = vkCreateMacOSSurfaceMVK(instance, &surfaceCreateInfo, nullptr, &surface);
    if (result != VK_SUCCESS)
    {
        std::cerr << "vkCreateMacOSSurfaceMVK failed with code: " << result << std::endl;
        throw std::runtime_error("failed to create window surface!");
    }
}

void mainLoop()
{
    while (!glfwWindowShouldClose(window))
    {
        glfwPollEvents();
    }
}

void cleanup()
{
    vkDestroySurfaceKHR(instance, surface, nullptr);
    vkDestroyInstance(instance, nullptr);
    glfwDestroyWindow(window);
    glfwTerminate();
}

int main()
{
    try
    {
        initWindow();
        setMetalLayerForWindow(window);
        initVulkan();
        mainLoop();
        cleanup();
    }
    catch (const std::exception &e)
    {
        std::cerr << e.what() << std::endl;
        return EXIT_FAILURE;
    }

    return EXIT_SUCCESS;
}
