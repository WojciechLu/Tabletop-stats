import { faPlus } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { FooterRendererProps } from "simple-table-core";
import "simple-table-core/styles.css";

interface FooterProps extends FooterRendererProps{
  onCreateLogClick: () => void,
}

const Footer = ({
  currentPage,
  startRow,
  endRow,
  totalRows,
  totalPages,
  hasPrevPage,
  hasNextPage,
  onPrevPage,
  onNextPage,
  onPageChange,
  onCreateLogClick
}: FooterProps) => {
  //   not supporting for now
  //   const isDark = theme === "dark";
  const isDark = false;
  const footerColors = {
    background: isDark ? "#1f2937" : "#f8fafc",
    border: isDark ? "#374151" : "#e2e8f0",
    text: isDark ? "#e5e7eb" : "#475569",
    buttonBg: isDark ? "#374151" : "white",
    buttonBorder: isDark ? "#4b5563" : "#e2e8f0",
    buttonActive: isDark ? "#3b82f6" : "#3b82f6",
    buttonText: isDark ? "#d1d5db" : "#64748b",
    buttonDisabled: isDark ? "#6b7280" : "#cbd5e1",
  };

  return (
    <div
      style={{
        display: "flex",
        alignItems: "center",
        justifyContent: "space-between",
        padding: "16px 20px",
        backgroundColor: footerColors.background,
        borderTop: `2px solid ${footerColors.border}`,
        fontFamily: "system-ui, -apple-system, sans-serif",
      }}
    >
      {/* Left side - Row info */}
      <div style={{ display: "flex", alignItems: "center", gap: "12px" }}>
        <button
          onClick={onCreateLogClick}
          style={{
            padding: "8px 12px",
            fontSize: "14px",
            fontWeight: 500,
            color: "white",
            backgroundColor: footerColors.buttonActive,
            border: `1px solid ${footerColors.buttonBorder}`,
            borderRadius: "6px",
            cursor: "pointer",
            transition: "all 0.2s",
            minWidth: "40px",
          }}
        >
          <FontAwesomeIcon icon={faPlus} />
        </button>
      </div>

      {/* Right side - Page controls */}
      <div style={{ display: "flex", alignItems: "center", gap: "8px" }}>
        <div>
          <span
            style={{
              fontSize: "14px",
              fontWeight: 600,
              color: footerColors.text,
            }}
          >
            Showing {startRow}-{endRow} of {totalRows} items
          </span>
        </div>
        <div></div>
        <button
          onClick={onPrevPage}
          disabled={!hasPrevPage}
          style={{
            padding: "8px 16px",
            fontSize: "14px",
            fontWeight: 500,
            color: hasPrevPage
              ? footerColors.buttonActive
              : footerColors.buttonDisabled,
            backgroundColor: footerColors.buttonBg,
            border: `1px solid ${footerColors.buttonBorder}`,
            borderRadius: "6px",
            cursor: hasPrevPage ? "pointer" : "not-allowed",
            transition: "all 0.2s",
          }}
        >
          Previous
        </button>

        {/* Page numbers */}
        <div style={{ display: "flex", gap: "4px" }}>
          {Array.from({ length: totalPages }, (_, i) => i + 1).map((page) => (
            <button
              key={page}
              onClick={() => onPageChange(page)}
              style={{
                padding: "8px 12px",
                fontSize: "14px",
                fontWeight: 500,
                color: currentPage === page ? "white" : footerColors.buttonText,
                backgroundColor:
                  currentPage === page
                    ? footerColors.buttonActive
                    : footerColors.buttonBg,
                border: `1px solid ${footerColors.buttonBorder}`,
                borderRadius: "6px",
                cursor: "pointer",
                transition: "all 0.2s",
                minWidth: "40px",
              }}
            >
              {page}
            </button>
          ))}
        </div>

        <button
          onClick={onNextPage}
          disabled={!hasNextPage}
          style={{
            padding: "8px 16px",
            fontSize: "14px",
            fontWeight: 500,
            color: hasNextPage
              ? footerColors.buttonActive
              : footerColors.buttonDisabled,
            backgroundColor: footerColors.buttonBg,
            border: `1px solid ${footerColors.buttonBorder}`,
            borderRadius: "6px",
            cursor: hasNextPage ? "pointer" : "not-allowed",
            transition: "all 0.2s",
          }}
        >
          Next
        </button>
      </div>
    </div>
  );
};

export default Footer;
